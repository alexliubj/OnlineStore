using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineStoreBLO;
using OnlineStoreDAL;
using OnlineStoreDAL.Models;

public partial class Registriation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Usermodel mdl = new Usermodel();
        //mdl.first_name = txtFName.Text;

        //UserBLO.CreateUser(mdl);
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        Usermodel mdl = new Usermodel();
        mdl.first_name = txtFName.Text;
        mdl.last_name = txtLName.Text;
        mdl.Password = txtPassword.Text;
        mdl.Email = txtEmail.Text;
        mdl.Address = txtAddress.Text;
    
       int result = UserBLO.CreateUser(mdl);
       if (result == 1)
       {
           if (!ClientScript.IsStartupScriptRegistered("alert"))
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(),
                   "alert", "alertMe();", true);
           }
       }
    }
}