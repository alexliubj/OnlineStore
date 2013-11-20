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
using OnlineStoreDAL.Models;
using OnlineStoreDAL;
using OnlineStoreBLO;

public partial class Catalog : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't reload data during postbacks
    if (!IsPostBack)
    {
      PopulateControls();
    }
  }

  // Fill the page with data
  private void PopulateControls()
  {
    // Retrieve DepartmentID from the query string
    string departmentId = Request.QueryString["DepartmentID"];
    // Retrieve CategoryID from the query string
    string categoryId = Request.QueryString["CategoryID"];
    // If browsing a category...
    if (categoryId != null)
    {
      // Retrieve category details and display them
      CategoryDetails cd = CatalogBLO.GetCategoryDetails(categoryId);
      catalogTitleLabel.Text = cd.Name;
      catalogDescriptionLabel.Text = cd.Description;
      // Set the title of the page
      this.Title = ShopConfiguration.SiteName +
                   " : Category : " + cd.Name;
    }
    // If browsing a department...
    else if (departmentId != null)
    {
      // Retrieve department details and display them
      DepartmentDetails dd = CatalogBLO.GetDepartmentDetails(departmentId);
      catalogTitleLabel.Text = dd.Name;
      catalogDescriptionLabel.Text = dd.Description;
      // Set the title of the page
      this.Title = ShopConfiguration.SiteName +
                   " : Department : " + dd.Name;
    }
  }
}
