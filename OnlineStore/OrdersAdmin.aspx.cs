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
public partial class OrdersAdmin : System.Web.UI.Page
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
                this.Title = ShopConfiguration.SiteName +
                              " : Orders Admin";
                // associate the check boxes with their buttons
                Utilities.TieButton(this.Page, recentCountTextBox, byRecentGo);
                Utilities.TieButton(this.Page, startDateTextBox, byDateGo);
                Utilities.TieButton(this.Page, endDateTextBox, byDateGo);

            }

            else
            {
                Response.Redirect("Oooops.aspx");
            }
        }
       
  }

  // list the most recent orders
  protected void byRecentGo_Click(object sender, EventArgs e)
  {
    // how many orders to list?
    int recordCount;
    // load the new data into the grid
    if (int.TryParse(recentCountTextBox.Text, out recordCount))
      grid.DataSource = OrderBLO.GetByRecent(recordCount);
    else
      errorLabel.Text = "<br />Please enter a valid number!";
    // refresh the data grid
    grid.DataBind();
    // no order is selected
    Session["AdminOrderID"] = null;
  }

  // list the orders that happened between specified dates
  protected void byDateGo_Click(object sender, EventArgs e)
  {
    // check if the page is valid (we have date validator controls)
    if ((Page.IsValid) && (startDateTextBox.Text + endDateTextBox.Text != ""))
    {
      // get the dates
      string startDate = startDateTextBox.Text;
      string endDate = endDateTextBox.Text;
      // load the grid with the requested data
      grid.DataSource = OrderBLO.GetByDate(startDate, endDate);
    }
    else
      errorLabel.Text = "<br />Please enter valid dates!";
    // refresh the data grid
    grid.DataBind();
    // no order is selected
    Session["AdminOrderID"] = null;
  }

  // get unverified, uncanceled orders
  protected void unverfiedGo_Click(object sender, EventArgs e)
  {
    // load the grid with the requested data
    grid.DataSource = OrderBLO.GetUnverifiedUncanceled();
    // refresh the data grid
    grid.DataBind();
    // no order is selected
    Session["AdminOrderID"] = null;
  }

  // get verified, but uncompleted orders
  protected void uncompletedGo_Click(object sender, EventArgs e)
  {
    // load the grid with the requested data
    grid.DataSource = OrderBLO.GetVerifiedUncompleted();
    // refresh the data grid
    grid.DataBind();
    // no order is selected
    Session["AdminOrderID"] = null;
  }

  // Load the details of the selected order
  protected void grid_SelectedIndexChanged(object sender, EventArgs e)
  {
    // Save the ID of the selected order in the session
    Session["AdminOrderID"] = grid.DataKeys[grid.SelectedIndex].Value.ToString();
  }
}
