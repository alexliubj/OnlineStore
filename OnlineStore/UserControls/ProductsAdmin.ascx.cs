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
public partial class ProductsAdmin : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Load the grid only the first time the page is loaded
    if (!Page.IsPostBack)
    {
      // Get CategoryID from the query string
      string categoryId = Request.QueryString["CategoryID"];
      // Obtain the category's name
      CategoryDetails cd = CatalogBLO.GetCategoryDetails(categoryId);
      string categoryName = cd.Name;
      // Set controls' properties
      statusLabel.ForeColor = System.Drawing.Color.Red;
      locationLabel.Text = "Displaying products for category <b> " 
                            + categoryName + "</b>";
      // Load the products grid
      BindGrid();
    }
  }

  // Populate the GridView with data
  private void BindGrid()
  {
    // Get CategoryID from the query string
    string categoryId = Request.QueryString["CategoryID"];
    // Get a DataTable object containing the products
    grid.DataSource = CatalogBLO.GetAllProductsInCategory(categoryId);
    // Needed to bind the data bound controls to the data source
    grid.DataBind();
  }

  // Enter row into edit mode
  protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
  {
    // Set the row for which to enable edit mode
    grid.EditIndex = e.NewEditIndex;
    // Set status message 
    statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
    // Reload the grid
    BindGrid();
  }

  // Cancel edit mode
  protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
  {
    // Cancel edit mode
    grid.EditIndex = -1;
    // Set status message
    statusLabel.Text = "Editing canceled";
    // Reload the grid
    BindGrid();
  }

  // Update a product
  protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
  {
    // Retrieve updated data
    string id = grid.DataKeys[e.RowIndex].Value.ToString();
    string name = ((TextBox)grid.Rows[e.RowIndex].FindControl("nameTextBox")).Text;
    string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
    string price = ((TextBox)grid.Rows[e.RowIndex].FindControl("priceTextBox")).Text;
    string image1FileName = ((TextBox)grid.Rows[e.RowIndex].FindControl("image1TextBox")).Text;
    string image2FileName = ((TextBox)grid.Rows[e.RowIndex].FindControl("image2TextBox")).Text;
    string onDepartmentPromotion = ((CheckBox)grid.Rows[e.RowIndex].Cells[6].Controls[0]).Checked.ToString();
    string onCatalogPromotion = ((CheckBox)grid.Rows[e.RowIndex].Cells[7].Controls[0]).Checked.ToString();
    // Execute the update command
    bool success = CatalogBLO.UpdateProduct(id, name, description, price, image1FileName, image2FileName, onDepartmentPromotion, onCatalogPromotion);
    // Cancel edit mode
    grid.EditIndex = -1;
    // Display status message
    statusLabel.Text = success ? "Product update successful" : "Product update failed";
    // Reload grid
    BindGrid();
  }

  // Create a new product
  protected void createProduct_Click(object sender, EventArgs e)
  {
    // Get CategoryID from the query string
    string categoryId = Request.QueryString["CategoryID"];
    // Execute the insert command
    bool success = CatalogBLO.CreateProduct(categoryId, newName.Text, newDescription.Text, newPrice.Text, newImage1FileName.Text, newImage2FileName.Text, newOnDepartmentPromotion.Checked.ToString(), newOnCatalogPromotion.Checked.ToString());
    // Display status message
    statusLabel.Text = success ? "Insert successful" : "Insert failed";
    // Reload the grid
    BindGrid();
  }

  // Go back to the list of categories
  protected void goBackLink_Click(object sender, EventArgs e)
  {
    // Get DepartmentID from the query string
    string departmentId = Request.QueryString["DepartmentID"];
    // Redirect
    Response.Redirect(Request.ApplicationPath + "/CatalogAdmin.aspx?DepartmentID=" + departmentId);
  }
}
