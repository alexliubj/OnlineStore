<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsAdmin.ascx.cs"
  Inherits="ProductsAdmin" %>
<asp:Label ID="statusLabel" runat="server" CssClass="AdminPageText" Text="Products Loaded"></asp:Label><br />
<br />
<asp:Label ID="locationLabel" runat="server" CssClass="AdminPageText" Text="Displaying products for category..."></asp:Label>
<asp:LinkButton ID="goBackLink" runat="server" CssClass="AdminPageText" OnClick="goBackLink_Click">(go back to categories)</asp:LinkButton><br />
<br />
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
  Width="100%" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating">
  <Columns>
    <asp:ImageField DataImageUrlField="Thumbnail" DataImageUrlFormatString="../ProductImages/{0}"
      HeaderText="Product Image" ReadOnly="True">
    </asp:ImageField>
    <asp:TemplateField HeaderText="Product Name" SortExpression="Name">
      <ItemTemplate>
        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="nameTextBox" runat="server" Width="97%" CssClass="GridEditingRow" Text='<%# Bind("Name") %>'></asp:TextBox>
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Product Description" SortExpression="Description">
      <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>'
          Height="100px" Width="97%" CssClass="GridEditingRow" TextMode="MultiLine" />
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Price" SortExpression="Price">
      <ItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="priceTextBox" runat="server" Width="45px" Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'></asp:TextBox>
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Image1 File" SortExpression="Image1FileName">
      <ItemTemplate>
        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="image1TextBox" Width="80px" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:TextBox>
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Image2 File" SortExpression="Image2FileName">
      <ItemTemplate>
        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="image2TextBox" Width="80px" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:CheckBoxField DataField="PromoDept" HeaderText="Dept. prom." 
          SortExpression="OnDepartmentPromotion" />
    <asp:CheckBoxField DataField="PromoFront" HeaderText="Cat. prom." 
          SortExpression="OnCatalogPromotion" />
    <asp:TemplateField>
      <ItemTemplate>
        <asp:HyperLink runat="server" Text="Select" NavigateUrl='<%# "../CatalogAdmin.aspx?DepartmentID=" + Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + Request.QueryString["CategoryID"] + "&amp;ProductID=" + Eval("ProductID") %>' ID="HyperLink1">
        </asp:HyperLink>
      </ItemTemplate>
    </asp:TemplateField>
    <asp:CommandField ShowEditButton="True" />
  </Columns>
</asp:GridView>
<br />
<span class="AdminPageText">Create a new product and assign it to this category:</span>
<table class="AdminPageText" cellspacing="0">
  <tr>
    <td width="100" valign="top">Name:</td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newName" Runat="server" Width="400px" />      
    </td>
  </tr>
  <tr>
    <td width="100" valign="top">Description:</td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newDescription" Runat="server" Width="400px" Height="70px" TextMode="MultiLine"/>
    </td>
  </tr>
  <tr>
    <td width="100" valign="top">Price:</td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newPrice" Runat="server" Width="400px">0.00</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td width="100" valign="top">Image1 File:</td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newImage1FileName" Runat="server" Width="400px">Generic1.png</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td width="150" valign="top">Image2 File:</td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newImage2FileName" Runat="server" Width="400px">Generic2.png</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td width="150" valign="top">Dept. Promotion:</td>
    <td>
      <asp:CheckBox ID="newOnDepartmentPromotion" Runat="server" />
    </td>
  </tr>
  <tr>
    <td width="150" valign="top">Catalog Promotion:</td>
    <td>
      <asp:CheckBox ID="newOnCatalogPromotion" Runat="server" />
    </td>
  </tr>
</table>
<asp:Button ID="createProduct" CssClass="Button"
  Runat="server" Text="Create Product" OnClick="createProduct_Click" />
