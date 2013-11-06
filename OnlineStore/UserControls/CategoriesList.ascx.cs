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
public partial class CategoriesList : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't reload data during postbacks
    if (!IsPostBack)
    {
      // Obtain the ID of the selected department
      string departmentId = Request.QueryString["DepartmentID"];
      // Continue only if DepartmentID exists in the query string
      if (departmentId != null)
      {
        // Catalog.GetCategoriesInDepartment returns a DataTable object containing
        // category data, which is displayed by the DataList
        list.DataSource = CatalogBLO.GetCategoriesInDepartment(departmentId);
        // Needed to bind the data bound controls to the data source
        list.DataBind();
        // Make space for the next control
        brLabel.Text = "<br />";
      }
    }
  }
}
