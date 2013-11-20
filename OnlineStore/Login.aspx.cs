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
public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // get references to the button, checkbox and textboxes
    TextBox usernameTextBox = (TextBox)login.FindControl("UserName");
    TextBox passwordTextBox = (TextBox)login.FindControl("Password");
    CheckBox persistCheckBox = (CheckBox)login.FindControl("RememberMe");
    Button loginButton = (Button)login.FindControl("LoginButton");
    // tie the two textboxes and the checkbox to the button
    Utilities.TieButton(this.Page, usernameTextBox, loginButton);
    Utilities.TieButton(this.Page, passwordTextBox, loginButton);
    Utilities.TieButton(this.Page, persistCheckBox, loginButton);
    // set the page title
    this.Title = ShopConfiguration.SiteName + " : Login";
    // set focus on the username textbox when the page loads
    usernameTextBox.Focus();
  }

  protected void LoginButton_Click(object sender, EventArgs e)
  {

  }
  protected void Button1_Click(object sender, EventArgs e)
  {
      Response.Redirect("Registration.aspx");
  }
}
