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
public partial class ProductRecommendations : System.Web.UI.UserControl
{
  protected void Page_PreRender(object sender, EventArgs e)
  {
    // Get the currently loaded page
    string currentLocation = Request.AppRelativeCurrentExecutionFilePath;
    // If we're in Product.aspx...
    if (currentLocation == "~/Product.aspx")
    {
      // get the product ID
      string productId = Request.QueryString["ProductID"];
      // get product recommendations
      DataTable table;
      // display recommendations            
      table = CatalogBLO.GetRecommendations(productId);
      list.DataSource = table;
      list.DataBind();
      // display header
      if (table.Rows.Count > 0)
        recommendationsHeader.Text = 
          "Customers who bought this product also bought:";
      else
        recommendationsHeader.Text = "";
    }
    // If we're in ShoppingCart.aspx...
    else if (currentLocation == "~/ShoppingCart.aspx")
    {
      // get product recommendations
      DataTable table;
      // display recommendations            
      table = ShoppingCartBLO.GetRecommendations();
      list.DataSource = table;
      list.DataBind();
      // display header
      if (table.Rows.Count > 0)
        recommendationsHeader.Text = 
          "Customers who bought these products also bought:";
      else
        recommendationsHeader.Text = "";
    }
  }
}
