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

public partial class UserInfo : System.Web.UI.UserControl
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
        else
        {
            divWelcome.Style.Add("display", "none");
        }
        if (Session["userid"] != null && Session["username"] != null) //login
        {
            if (result == 1)
            {
                testHide.Style.Add("display", "block");
                loginDiv.Style.Add("display", "none");
                divWelcome.Style.Add("display", "block");
            }
            else if (result == 0)
            {
                testHide.Style.Add("display", "none");
                loginDiv.Style.Add("display", "none");
                divWelcome.Style.Add("display", "block");
            }
            else
            { }

        }
        else
        {
            testHide.Style.Add("display", "none");
            loginDiv.Style.Add("display", "block");
        }
        if (Session["username"] != null)

            Label1.Text = Session["username"].ToString();
    }
    protected void login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
        testHide.Style.Add("display", "none");
        loginDiv.Style.Add("display", "block");
        divWelcome.Style.Add("display", "none");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
    }
}
