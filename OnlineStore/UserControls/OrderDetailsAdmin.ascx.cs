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
public partial class OrderDetailsAdmin : System.Web.UI.UserControl
{
  // edit mode by default is false
  private bool editMode = false;

  // set up the form
  protected void Page_PreRender(object sender, EventArgs e)
  {
    // check if we must display order details       
    if (Session["AdminOrderID"] != null)
    {
      // fill constituent controls with data
      PopulateControls();
      // set edit mode
      SetEditMode(editMode);
    }
    else
    //   Hide
      this.Visible = false;
  }

  // populate the form with data
  private void PopulateControls()
  {
    // obtain order ID from the session
    string orderId = Session["AdminOrderID"].ToString();
    // obtain order info
    OrderInfo orderInfo = OrderBLO.GetInfo(orderId);
    // populate labels and text boxes with order info
    orderIdLabel.Text = "Displaying Order #" + orderId;
    totalAmountLabel.Text = String.Format("{0:c}", orderInfo.TotalAmount);
    dateCreatedTextBox.Text = orderInfo.DateCreated;
    dateShippedTextBox.Text = orderInfo.DateShipped;
    verifiedCheck.Checked = orderInfo.Verified;
    completedCheck.Checked = orderInfo.Completed;
    canceledCheck.Checked = orderInfo.Canceled;
    commentsTextBox.Text = orderInfo.Comments;
    customerNameTextBox.Text = orderInfo.CustomerName;
    shippingAddressTextBox.Text = orderInfo.ShippingAddress;
    customerEmailTextBox.Text = orderInfo.CustomerEmail;
    // by default the Edit button is enabled, and the
    // Update and Cancel buttons are disabled
    editButton.Enabled = true;
    updateButton.Enabled = false;
    cancelButton.Enabled = false;
    // Decide which one of the other three buttons
    // should be enabled and which should be disabled
    if (canceledCheck.Checked || completedCheck.Checked)
    {
      // if the order was canceled or completed ...
      markVerifiedButton.Enabled = false;
      markCompletedButton.Enabled = false;
      markCanceledButton.Enabled = false;
    }
    else if (verifiedCheck.Checked)
    {
      // if the order was not canceled but is verified ...
      markVerifiedButton.Enabled = false;
      markCompletedButton.Enabled = true;
      markCanceledButton.Enabled = true;
    }
    else
    {
      // if the order was not canceled and is not verified ...
      markVerifiedButton.Enabled = true;
      markCompletedButton.Enabled = false;
      markCanceledButton.Enabled = true;
    }
    // fill the data grid with order details
    grid.DataSource = OrderBLO.GetDetails(orderId);
    grid.DataBind();
  }

  // enable or disable edit mode
  private void SetEditMode(bool enable)
  {
    dateCreatedTextBox.Enabled = enable;
    dateShippedTextBox.Enabled = enable;
    verifiedCheck.Enabled = enable;
    completedCheck.Enabled = enable;
    canceledCheck.Enabled = enable;
    commentsTextBox.Enabled = enable;
    customerNameTextBox.Enabled = enable;
    shippingAddressTextBox.Enabled = enable;
    customerEmailTextBox.Enabled = enable;
    editButton.Enabled = !enable;
    updateButton.Enabled = enable;
    cancelButton.Enabled = enable;
  }

  // enter edit mode
  protected void editButton_Click(object sender, EventArgs e)
  {
    editMode = true;
  }

  // cancel edit mode
  protected void cancelButton_Click(object sender, EventArgs e)
  {
    // don't need to do anything, editMode will be set to false by default
  }

  // update order information
  protected void updateButton_Click(object sender, EventArgs e)
  {
    // Store the new order details in an OrderInfo object
    OrderInfo orderInfo = new OrderInfo();
    string orderId = Session["AdminOrderID"].ToString();
    orderInfo.OrderID = Int32.Parse(orderId);
    orderInfo.DateCreated = dateCreatedTextBox.Text;
    orderInfo.DateShipped = dateShippedTextBox.Text;
    orderInfo.Verified = verifiedCheck.Checked;
    orderInfo.Completed = completedCheck.Checked;
    orderInfo.Canceled = canceledCheck.Checked;
    orderInfo.Comments = commentsTextBox.Text;
    orderInfo.CustomerName = customerNameTextBox.Text;
    orderInfo.ShippingAddress = shippingAddressTextBox.Text;
    orderInfo.CustomerEmail = customerEmailTextBox.Text;
    // try to update the order     
    try
    {
      // Update the order
      OrderBLO.Update(orderInfo);
    }
    catch (Exception ex)
    {
      // In case of an error, we simply ignore it
    }
    // Exit edit mode 
    SetEditMode(false);
    // Update the form
    PopulateControls();
  }

  // mark order as verified
  protected void markVerifiedButton_Click(object sender, EventArgs e)
  {
    // obtain the order ID from the session
    string orderId = Session["AdminOrderID"].ToString();
    // mark order as verified
    OrderBLO.MarkVerified(orderId);
    // update the form
    PopulateControls();
  }

  // mark order as completed
  protected void markCompletedButton_Click(object sender, EventArgs e)
  {
    // obtain the order ID from the session
    string orderId = Session["AdminOrderID"].ToString();
    // mark the order as completed
    OrderBLO.MarkCompleted(orderId);
    // update the form
    PopulateControls();
  }

  // mark order as canceled
  protected void markCanceledButton_Click(object sender, EventArgs e)
  {
    // obtain the order ID from the session
    string orderId = Session["AdminOrderID"].ToString();
    // mark the order as canceled
    OrderBLO.MarkCanceled(orderId);
    // update the form
    PopulateControls();
  }
}
