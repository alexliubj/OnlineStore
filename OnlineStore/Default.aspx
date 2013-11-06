<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Welcome to BalloonShop!" %>

<%@ Register Src="UserControls/ProductsList.ascx" TagName="ProductsList" TagPrefix="uc1" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" Runat="server">
  <span class="CatalogTitle">Welcome to BalloonShop! </span>
  <br />
  <span class="CatalogDescription">This week we have a special price for these fantastic products: </span>
  <br />
  <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>

