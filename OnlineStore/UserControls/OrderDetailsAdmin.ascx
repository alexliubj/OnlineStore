<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderDetailsAdmin.ascx.cs" Inherits="OrderDetailsAdmin" %>
<asp:Label ID="orderIdLabel" runat="server" 
           CssClass="AdminTitle" Text="Order #000" />
<br /><br />
<table class="AdminPageText">
  <tr>
    <td width="130">Total Amount:</td>
    <td>
      <asp:Label ID="totalAmountLabel" runat="server" CssClass="ProductPrice" />
    </td>
  </tr>
  <tr>
    <td width="130">Date Created:</td>
    <td>
      <asp:TextBox ID="dateCreatedTextBox" runat="server" Width="400px" />
    </td>
  </tr>
  <tr>
    <td width="130">Date Shipped:</td>
    <td>
      <asp:TextBox ID="dateShippedTextBox" runat="server" Width="400px" />
    </td>
  </tr>
  <tr>
    <td width="130">Verified:</td>
    <td>
      <asp:CheckBox ID="verifiedCheck" runat="server" />
    </td>
  </tr>
  <tr>
    <td width="130">Completed:</td>
    <td>
      <asp:CheckBox ID="completedCheck" runat="server" />
    </td>
  </tr>
  <tr>
    <td width="130">Canceled:</td>
    <td>
      <asp:CheckBox ID="canceledCheck" runat="server" />
    </td>
  </tr>
  <tr>
    <td width="130">Comments:</td>
    <td>
      <asp:TextBox ID="commentsTextBox" runat="server" Width="400px" />
    </td>
  </tr>
  <tr>
    <td width="130">Customer Name:</td>
    <td>
      <asp:TextBox ID="customerNameTextBox" runat="server" Width="400px" />
    </td>
  </tr>
  <tr>
    <td width="130">Shipping Address:</td>
    <td>
      <asp:TextBox ID="shippingAddressTextBox" runat="server" Width="400px" />
    </td>
  </tr>
  <tr>
    <td width="130">Customer Email:</td>
    <td>
      <asp:TextBox ID="customerEmailTextBox" runat="server" Width="400px" />
    </td>
  </tr>
</table>
<br />
<asp:Button ID="editButton" runat="server" CssClass="SmallButtonText" 
            Text="Edit" Width="100px" OnClick="editButton_Click" />
<asp:Button ID="updateButton" runat="server" CssClass="SmallButtonText" 
            Text="Update" Width="100px" OnClick="updateButton_Click" />
<asp:Button ID="cancelButton" runat="server" CssClass="SmallButtonText" 
            Text="Cancel" Width="100px" OnClick="cancelButton_Click" /><br />
<asp:Button ID="markVerifiedButton" runat="server" CssClass="SmallButtonText" 
            Text="Mark Order as Verified" Width="310px" OnClick="markVerifiedButton_Click" /><br />
<asp:Button ID="markCompletedButton" runat="server" CssClass="SmallButtonText" 
            Text="Mark Order as Completed" Width="310px" OnClick="markCompletedButton_Click" /><br />
<asp:Button ID="markCanceledButton" runat="server" CssClass="SmallButtonText" 
            Text="Mark Order as Canceled" Width="310px" OnClick="markCanceledButton_Click" /><br />
<br />
<asp:Label ID="Label13" runat="server" CssClass="AdminPageText" Text="The order contains these items:" />
<br />
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
BackColor="White" Width="100%">
  <Columns>
    <asp:BoundField DataField="ProductID" HeaderText="Product ID" 
                    ReadOnly="True" SortExpression="ProductID" />
    <asp:BoundField DataField="ProductName" HeaderText="Product Name" 
                    ReadOnly="True" SortExpression="ProductName" />
    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                    ReadOnly="True" SortExpression="Quantity" />
    <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" 
                    ReadOnly="True" SortExpression="UnitCost" />
    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" 
                    ReadOnly="True" SortExpression="Subtotal" />
  </Columns>
</asp:GridView>
