<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ShoppingCartAdmin.aspx.cs" Inherits="ShoppingCartAdmin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <span class="AdminTitle">Shopping Cart Admin</span></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <asp:Label ID="countLabel" runat="server" CssClass="AdminPageText">
      Hello!
  </asp:Label><br />
  <span class="AdminPageText">How many days?</span>
  <asp:DropDownList ID="daysList" runat="server">
    <asp:ListItem Value="0">All shopping carts</asp:ListItem>
    <asp:ListItem Value="1">One</asp:ListItem>
    <asp:ListItem Value="10" Selected="True">Ten</asp:ListItem>
    <asp:ListItem Value="20">Twenty</asp:ListItem>
    <asp:ListItem Value="30">Thirty</asp:ListItem>
    <asp:ListItem Value="90">Ninety</asp:ListItem>
  </asp:DropDownList><br />
  <br />
  <asp:Button ID="countButton" runat="server" Text="Count Old Shopping Carts" CssClass="Button" OnClick="countButton_Click" />
  <asp:Button ID="deleteButton" runat="server" Text="Delete Old Shopping Carts" CssClass="Button" OnClick="deleteButton_Click" /></asp:Content>

