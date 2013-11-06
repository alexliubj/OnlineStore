<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="OrdersAdmin.aspx.cs"
  Inherits="OrdersAdmin" Title="Untitled Page" %>

<%@ Register Src="UserControls/OrderDetailsAdmin.ascx" TagName="OrderDetailsAdmin"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <span class="AdminTitle">Orders Admin</span></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <span class="AdminPageText">Show the most recent
    <asp:TextBox ID="recentCountTextBox" runat="server" MaxLength="4" Width="40px" Text="20" />
    records
    <asp:Button ID="byRecentGo" runat="server" CssClass="SmallButtonText" Text="Go" OnClick="byRecentGo_Click"
      CausesValidation="False" /><br />
    Show all records created between
    <asp:TextBox ID="startDateTextBox" runat="server" Width="72px" />
    and
    <asp:TextBox ID="endDateTextBox" runat="server" Width="72px" />
    <asp:Button ID="byDateGo" runat="server" CssClass="SmallButtonText" Text="Go" OnClick="byDateGo_Click" />
    <br />
    Show all unverified, uncanceled orders
    <asp:Button ID="unverfiedGo" runat="server" CssClass="SmallButtonText" Text="Go"
      OnClick="unverfiedGo_Click" CausesValidation="False" />
    <br />
    Show all verified, uncompleted orders
    <asp:Button ID="uncompletedGo" runat="server" CssClass="SmallButtonText" Text="Go"
      OnClick="uncompletedGo_Click" CausesValidation="False" />
    <br />
    <asp:Label ID="errorLabel" runat="server" CssClass="AdminErrorText" EnableViewState="False"></asp:Label>
    <asp:RangeValidator ID="startDateValidator" runat="server" ControlToValidate="startDateTextBox"
      Display="None" ErrorMessage="Invalid start date" MaximumValue="1/1/2009" MinimumValue="1/1/1999"
      Type="Date"></asp:RangeValidator>
    <asp:RangeValidator ID="endDateValidator" runat="server" ControlToValidate="endDateTextBox"
      Display="None" ErrorMessage="Invalid end date" MaximumValue="1/1/2009" MinimumValue="1/1/1999"
      Type="Date"></asp:RangeValidator>
    <asp:CompareValidator ID="compareDatesValidator" runat="server" ControlToCompare="endDateTextBox"
      ControlToValidate="startDateTextBox" Display="None" ErrorMessage="Start date should be more recent than end date"
      Operator="LessThan" Type="Date"></asp:CompareValidator><br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="AdminErrorText"
      HeaderText="Please fix these errors before submitting requests:" />
    <br />
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" OnSelectedIndexChanged="grid_SelectedIndexChanged">
      <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True" SortExpression="OrderID" />
        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" ReadOnly="True"
          SortExpression="DateCreated" />
        <asp:BoundField DataField="DateShipped" HeaderText="Date Shipped" ReadOnly="True"
          SortExpression="DateShipped" />
        <asp:CheckBoxField DataField="Verified" HeaderText="Verified" ReadOnly="True" SortExpression="Verified" />
        <asp:CheckBoxField DataField="Completed" HeaderText="Completed" ReadOnly="True" SortExpression="Completed" />
        <asp:CheckBoxField DataField="Canceled" HeaderText="Canceled" ReadOnly="True" SortExpression="Canceled" />
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="True"
          SortExpression="CustomerName" />
        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
      </Columns>
    </asp:GridView>
    <br />
    <uc1:OrderDetailsAdmin EnableViewState="false" id="orderDetailsAdmin" runat="server">
    </uc1:OrderDetailsAdmin>
  </span>
</asp:Content>
