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
public partial class ShoppingCartAdmin : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
      int result = 10;
        if (Session["role_type"] != null)
        {
            if (Int32.TryParse(Session["role_type"].ToString(), out result))
            {
                result = Int32.Parse(Session["role_type"].ToString());
            }
        }

        if (Session["userid"] != null && Session["username"] != null) //login
        {
            if (result == 1)
            {

                // Set the title of the page
                this.Title = ShopConfiguration.SiteName +
                              " : Shopping Cart Admin";
            }
            else
            {
                Response.Redirect("Oooops.aspx");
            }
        }
        
  }

  // counts old shopping carts
  protected void countButton_Click(object sender, EventArgs e)
  {
    byte days = byte.Parse(daysList.SelectedItem.Value);
    int oldItems = ShoppingCartBLO.CountOldCarts(days);
    if (oldItems == -1)
      countLabel.Text = "Could not count the old shopping carts!";
    else if (oldItems == 0)
      countLabel.Text = "There are no old shopping carts.";
    else
      countLabel.Text = "There are " + oldItems.ToString() +
                        " old shopping carts.";
  }


  // deletes old shopping carts
  protected void deleteButton_Click(object sender, EventArgs e)
  {
    byte days = byte.Parse(daysList.SelectedItem.Value);
    ShoppingCartBLO.DeleteOldCarts(days);
    countLabel.Text = "The old shopping carts were removed from the database";
  }
}
