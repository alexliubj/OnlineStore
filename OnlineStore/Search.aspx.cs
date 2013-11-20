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
public partial class Search : System.Web.UI.Page
{
  // Fill the form with data
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't reload data during postbacks
    if (!IsPostBack)
    {
      // fill the table contents
      string searchString = Request.QueryString["Search"];
      titleLabel.Text = "Product Search";
      descriptionLabel.Text = "You searched for <font color=\"red\">" + searchString + "</font>.";
      // set the title of the page
      this.Title = ShopConfiguration.SiteName +
                    " : Product Search : " + searchString;
    }
  }
}
