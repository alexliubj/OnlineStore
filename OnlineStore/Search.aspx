<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="Untitled Page" %>

<%@ Register Src="UserControls/ProductsList.ascx" TagName="ProductsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" Runat="Server">
  <asp:Label ID="titleLabel" runat="server" CssClass="CatalogTitle"></asp:Label><br />
  <asp:Label ID="descriptionLabel" runat="server" CssClass="CatalogDescription"></asp:Label><br /><br />
  <uc1:productslist id="ProductsList1" runat="server"></uc1:productslist>
</asp:Content>

