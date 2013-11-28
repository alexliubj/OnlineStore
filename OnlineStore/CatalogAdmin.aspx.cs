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
public partial class CatalogAdmin : System.Web.UI.Page
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
                this.Title = ShopConfiguration.SiteName + " : Catalog Admin";
                // Get DepartmentID from the query string
                string departmentId = Request.QueryString["DepartmentID"];
                // Get CategoryID from the query string
                string categoryId = Request.QueryString["CategoryID"];
                // Get ProductID from the query string
                string productId = Request.QueryString["ProductID"];
                // Load the appropriate control into the place holder
                if (departmentId == null)
                {
                    Control c = Page.LoadControl(Request.ApplicationPath + "/UserControls/DepartmentsAdmin.ascx");
                    adminPlaceHolder.Controls.Add(c);
                }
                else if (categoryId == null)
                {
                    Control c = Page.LoadControl(Request.ApplicationPath + "/UserControls/CategoriesAdmin.ascx");
                    adminPlaceHolder.Controls.Add(c);
                }
                else if (productId == null)
                {
                    Control c = Page.LoadControl(Request.ApplicationPath + "/UserControls/ProductsAdmin.ascx");
                    adminPlaceHolder.Controls.Add(c);
                }
                else
                {
                    Control c = Page.LoadControl(Request.ApplicationPath + "/UserControls/ProductDetailsAdmin.ascx");
                    adminPlaceHolder.Controls.Add(c);
                }
            }
            else
            {
                Response.Redirect("Oooops.aspx");
            }
        }
       
  }
}