<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDetailsAdmin.ascx.cs" Inherits="ProductDetailsAdmin" %>
<span class="AdminPageText">
  <asp:Label ID="productNameLabel" runat="server" CssClass="AdminTitle" />
  <asp:HyperLink ID="goBackLink" runat="server">(go back to products)</asp:HyperLink>
  <br /><br />
  <asp:Label ID="statusLabel" runat="server" CssClass="AdminPageText" Text="Product Details Loaded" ForeColor="Red"></asp:Label><br />
  <br />
Product belongs to these categories:
  <asp:Label ID="categoriesLabel" runat="server"></asp:Label>
  <br />
Remove product from this category:
  <asp:DropDownList ID="categoriesListRemove" runat="server">
  </asp:DropDownList>
  <asp:Button ID="removeButton" runat="server" Text="Go!" OnClick="removeButton_Click" />
  <asp:Button ID="deleteButton" runat="server" Text="DELETE FROM CATALOG" OnClick="deleteButton_Click" /><br />
Assign product to this category:
  <asp:DropDownList ID="categoriesListAssign" runat="server">
  </asp:DropDownList>
  <asp:Button ID="assignButton" runat="server" Text="Go!" OnClick="assignButton_Click" />
  <br />
  <asp:Label ID="moveLabel" runat="server" Text="Move product to this category:"/>
  <asp:DropDownList ID="categoriesListMove" runat="server">
  </asp:DropDownList>
  <asp:Button ID="moveButton" runat="server" Text="Go!" OnClick="moveButton_Click" />
  <br />
Image1 file name:
  <asp:Label ID="image1FileNameLabel" runat="server"></asp:Label>
  <asp:FileUpload ID="image1FileUpload" runat="server" />
  <asp:Button ID="upload1Button" runat="server" Text="Upload" OnClick="upload1Button_Click" /><br />
  <asp:Image ID="image1" runat="server" />
  <br />
Image2 file name:
  <asp:Label ID="image2FileNameLabel" runat="server"></asp:Label>
  <asp:FileUpload ID="image2FileUpload" runat="server" />
  <asp:Button ID="upload2Button" runat="server" Text="Upload" OnClick="upload2Button_Click" /><br />
  <asp:Image ID="image2" runat="server" />
</span>
