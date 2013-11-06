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

public partial class BalloonShop : System.Web.UI.MasterPage
{
  // Website pages considered to be "catalog pages" that the visitor 
  // can "Continue Shopping" to
  private static string[] catalogPages = { "~/Default.aspx", "~/Catalog.aspx", "~/Search.aspx" };

  // Executes when any page based on this master page loads
  protected void Page_Load(object sender, EventArgs e)
  {
    // Don't perform any actions on postback events
    if (!IsPostBack)
    {
      /* Save the latest visited catalog page into the session
        to support "Continue Shopping" functionality */
      // Get the currently loaded page
      string currentLocation = Request.AppRelativeCurrentExecutionFilePath;
      // If the page is one of those we want the visitor to "continue shopping"
      // to, then save it to visitor's Session
      for (int i = 0; i < catalogPages.GetLength(0); i++)
        if (String.Compare(catalogPages[i], currentLocation, true) == 0)
        {
          // save the current location
          Session["LastVisitedCatalogPage"] = Request.Url.ToString();
          // stop the for loop from continuing
          break;
        }
    }
  }
}
