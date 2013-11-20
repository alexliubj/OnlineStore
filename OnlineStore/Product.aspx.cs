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

public partial class Product : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't reload data during postbacks
    if (!IsPostBack)
    {
      PopulateControls();
    }
  }

  // Fill the control with data
  private void PopulateControls()
  {
    // Retrieve ProductID from the query string
    string productId = Request.QueryString["ProductID"];
    // stores product details
    ProductDetails pd;
    // Retrieve product details 
    pd = CatalogBLO.GetProductDetails(productId);
    // Display product details
    titleLabel.Text = pd.Name;
    descriptionLabel.Text = pd.Description;
    priceLabel.Text = String.Format("{0:c}", pd.Price);
    productImage.ImageUrl = "ProductImages/" + pd.Image2FileName;
    // Set the title of the page
    this.Title = ShopConfiguration.SiteName +
                 " : Product : " + pd.Name;
  }

  // Add the product to cart
  protected void addToCartButton_Click(object sender, EventArgs e)
  {
    // Retrieve ProductID from the query string
    string productId = Request.QueryString["ProductID"];
    // Add the product to the shopping cart
    ShoppingCartBLO.AddItem(productId);
  }

  // Redirects to the previously visited catalog page 
  protected void continueShoppingButton_Click(object sender, EventArgs e)
  {
    // redirect to the last visited catalog page
    object page;
    if ((page = Session["LastVisitedCatalogPage"]) != null)
      Response.Redirect(page.ToString());
    else
      Response.Redirect(Request.ApplicationPath);
  }
}
