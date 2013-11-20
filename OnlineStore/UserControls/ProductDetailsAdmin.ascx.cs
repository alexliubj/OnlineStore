using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OnlineStoreDAL;
using OnlineStoreDAL.Models;
using OnlineStoreBLO;
public partial class ProductDetailsAdmin : System.Web.UI.UserControl
{
  // store product, category and department IDs as class members
  private string currentProductId, currentCategoryId, currentDepartmentId;

  protected void Page_Load(object sender, EventArgs e)
  {
    // Get DepartmentID, CategoryID, ProductID from the query string 
    // and save their values
    currentDepartmentId = Request.QueryString["DepartmentID"];
    currentCategoryId = Request.QueryString["CategoryID"];
    currentProductId = Request.QueryString["ProductID"];
    // Assign buttons to the combo boxes 
    Utilities.TieButton(this.Page, categoriesListRemove, removeButton);
    Utilities.TieButton(this.Page, categoriesListAssign, assignButton);
    Utilities.TieButton(this.Page, categoriesListMove, moveButton);
    // Fill the controls with data only on the initial page load
    if (!IsPostBack)
    {
      // Fill controls with data
      PopulateControls();
    }
  }

  // Populate the controls
  private void PopulateControls()
  {
    // Set the "go back to products" link
    goBackLink.NavigateUrl = Request.ApplicationPath +
        String.Format("/CatalogAdmin.aspx?DepartmentID={0}&CategoryID={1}",
                        currentDepartmentId, currentCategoryId);
    // Retrieve product details and category details from database
    ProductDetails productDetails = CatalogBLO.GetProductDetails(currentProductId);
    CategoryDetails categoryDetails = CatalogBLO.GetCategoryDetails(currentCategoryId);
    // Set up labels and images
    productNameLabel.Text = productDetails.Name;
    moveLabel.Text = "Move product from category <b>" + categoryDetails.Name + "</b> to this category: ";
    image1.ImageUrl = Request.ApplicationPath + "/ProductImages/" + productDetails.Image1FileName;
    image2.ImageUrl = Request.ApplicationPath + "/ProductImages/" + productDetails.Image2FileName;
    // Clear form
    categoriesLabel.Text = "";
    categoriesListAssign.Items.Clear();
    categoriesListMove.Items.Clear();
    categoriesListRemove.Items.Clear();
    // Fill categoriesLabel and categoriesListRemove with data
    string categoryId, categoryName;
    DataTable productCategories = CatalogBLO.GetCategoriesWithProduct(currentProductId);
    for (int i = 0; i < productCategories.Rows.Count; i++)
    {
      // obtain category id and name
      categoryId = productCategories.Rows[i]["CategoryId"].ToString();
      categoryName = productCategories.Rows[i]["Name"].ToString();
      // add a link to the category admin page
      categoriesLabel.Text += (categoriesLabel.Text == "" ? "" : ", ") +
          "<a href=\"" + Request.ApplicationPath + "/CatalogAdmin.aspx" +
          "?DepartmentID=" + CatalogBLO.GetCategoryDetails(currentCategoryId).DepartmentId +
          "&CategoryID=" + categoryId + "\">" +
          categoryName + "</a>";
      // populate the categoriesListRemove combo box
      categoriesListRemove.Items.Add(new ListItem(categoryName, categoryId));
    }
    // Delete from catalog or remove from category?
    if (productCategories.Rows.Count > 1)
    {
      deleteButton.Visible = false;
      removeButton.Enabled = true;
    }
    else
    {
      deleteButton.Visible = true;
      removeButton.Enabled = false;
    }
    // Fill categoriesListMove and categoriesListAssign with data
    productCategories = CatalogBLO.GetCategoriesWithoutProduct(currentProductId);
    for (int i = 0; i < productCategories.Rows.Count; i++)
    {
      // obtain category id and name
      categoryId = productCategories.Rows[i]["CategoryId"].ToString();
      categoryName = productCategories.Rows[i]["Name"].ToString();
      // populate the list boxes
      categoriesListAssign.Items.Add(new ListItem(categoryName, categoryId));
      categoriesListMove.Items.Add(new ListItem(categoryName, categoryId));
    }
  }

  // Remove the product from a category
  protected void removeButton_Click(object sender, EventArgs e)
  {
    // Check if a category was selected
    if (categoriesListRemove.SelectedIndex != -1)
    {
      // Get the category ID that was selected in the DropDownList
      string categoryId = categoriesListRemove.SelectedItem.Value;
      // Remove the product from the category 
      bool success = CatalogBLO.RemoveProductFromCategory(currentProductId, categoryId);
      // Display status message
      statusLabel.Text = success ? "Product removed successfully" : "Product removal failed";
      // Refresh the page
      PopulateControls();
    }
    else
      statusLabel.Text = "You need to select a category";
  }

  // delete a product from the catalog
  protected void deleteButton_Click(object sender, EventArgs e)
  {
    // Delete the product from the catalog
    CatalogBLO.DeleteProduct(currentProductId);
    // Need to go back to the categories page now
    Response.Redirect(Request.ApplicationPath + "/CatalogAdmin.aspx" +
            "?DepartmentID=" + currentDepartmentId +
            "&CategoryID=" + currentCategoryId);
  }

  // assign the product to a new category
  protected void assignButton_Click(object sender, EventArgs e)
  {
    // Check if a category was selected
    if (categoriesListAssign.SelectedIndex != -1)
    {
      // Get the category ID that was selected in the DropDownList
      string categoryId = categoriesListAssign.SelectedItem.Value;
      // Assign the product to the category
      bool success = CatalogBLO.AssignProductToCategory(currentProductId, categoryId);
      // Display status message
      statusLabel.Text = success ? "Product assigned successfully" : "Product assignation failed";
      // Refresh the page
      PopulateControls();
    }
    else
      statusLabel.Text = "You need to select a category";
  }

  // move the product to another category
  protected void moveButton_Click(object sender, EventArgs e)
  {
    // Check if a category was selected
    if (categoriesListMove.SelectedIndex != -1)
    {
      // Get the category ID that was selected in the DropDownList
      string newCategoryId = categoriesListMove.SelectedItem.Value;
      // Move the product to the category
      bool success = CatalogBLO.MoveProductToCategory(currentProductId, currentCategoryId, newCategoryId);
      // In case the operation was successful, reload the page, 
      // so the new category will reflect in the query string
      if (!success)
        statusLabel.Text = "Couldn't move the product to the specified category";
      else
        Response.Redirect(Request.ApplicationPath + "/CatalogAdmin.aspx" +
              "?DepartmentID=" + currentDepartmentId +
              "&CategoryID=" + newCategoryId +
              "&ProductID=" + currentProductId);
    }
    else
      statusLabel.Text = "You need to select a category";
  }

  // upload product's first image
  protected void upload1Button_Click(object sender, EventArgs e)
  {
    // proceed with uploading only if the user selected a file
    if (image1FileUpload.HasFile)
    {
      try
      {
        string fileName = image1FileUpload.FileName;
        string location = Server.MapPath("./ProductImages/") + fileName;
        // save image to server
        image1FileUpload.SaveAs(location);
        // update database with new product details
        ProductDetails pd = CatalogBLO.GetProductDetails(currentProductId);
        CatalogBLO.UpdateProduct(currentProductId, pd.Name, pd.Description, pd.Price.ToString(), fileName, pd.Image2FileName, pd.OnDepartmentPromotion.ToString(), pd.OnCatalogPromotion.ToString());
        // reload the page 
        Response.Redirect(Request.ApplicationPath + "/CatalogAdmin.aspx" +
                "?DepartmentID=" + currentDepartmentId +
                "&CategoryID=" + currentCategoryId +
                "&ProductID=" + currentProductId);
      }
      catch
      {
        statusLabel.Text = "Uploading image 1 failed";
      }
    }
  }

  // upload product's second image
  protected void upload2Button_Click(object sender, EventArgs e)
  {
    // proceed with uploading only if the user selected a file
    if (image2FileUpload.HasFile)
    {
      try
      {
        string fileName = image2FileUpload.FileName;
        string location = Server.MapPath("./ProductImages/") + fileName;
        // save image to server
        image2FileUpload.SaveAs(location);
        // update database with new product details
        ProductDetails pd = CatalogBLO.GetProductDetails(currentProductId);
        CatalogBLO.UpdateProduct(currentProductId, pd.Name, pd.Description, pd.Price.ToString(), pd.Image1FileName, fileName, pd.OnDepartmentPromotion.ToString(), pd.OnCatalogPromotion.ToString());
        // reload the page 
        Response.Redirect(Request.ApplicationPath + "/CatalogAdmin.aspx" +
                "?DepartmentID=" + currentDepartmentId +
                "&CategoryID=" + currentCategoryId +
                "&ProductID=" + currentProductId);
      }
      catch
      {
        statusLabel.Text = "Uploading image 2 failed";
      }
    }
  }
}
