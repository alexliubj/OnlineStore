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
public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    this.Title = ShopConfiguration.SiteName + " : Login";
    // set focus on the username textbox when the page loads
  }
  protected void Button1_Click(object sender, EventArgs e)
  {
      Response.Redirect("Registration.aspx");
  }
  protected void LoginButton_Click(object sender, EventArgs e)
  {
      TextBox usernameTextBox = UserName;
      TextBox passwordTextBox = Password;
    Usermodel model = UserBLO.getUserInfoByUseranme(usernameTextBox.Text, passwordTextBox.Text);
    if (model != null) // redirect
    {
        Session["userid"] = model.user_id.ToString();
        Session["username"] = model.first_name;
        Session["useremail"] = model.Email;
        Session["useraddress"] = model.Address;
        Session["role_type"] = model.role_type;
        Response.Redirect("Default.aspx");
    }
    else
    { 
        //alert
    }
  }
}
