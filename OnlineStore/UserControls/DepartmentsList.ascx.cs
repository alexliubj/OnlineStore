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
public partial class DepartmentsList : System.Web.UI.UserControl
{
  // Load department details into the DataList
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't reload data during postbacks
    if (!IsPostBack)
    {
      // CatalogAccess.GetDepartments returns a DataTable object containing
      // department data, which is read in the ItemTemplate of the DataList
      list.DataSource = CatalogBLO.GetDepartments();
      // Needed to bind the data bound controls to the data source
      list.DataBind();
    }
  }
}
