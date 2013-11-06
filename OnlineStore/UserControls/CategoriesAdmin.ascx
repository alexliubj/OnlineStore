<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoriesAdmin.ascx.cs"
  Inherits="CategoriesAdmin" %>
<asp:Label ID="statusLabel" runat="server" CssClass="AdminPageText" Text="Categories Loaded"></asp:Label><br />
<br />
<asp:Label ID="locationLabel" runat="server" CssClass="AdminPageText" Text="Displaying categories for department..."></asp:Label>
<asp:LinkButton ID="goBackLink" runat="server" CssClass="AdminPageText" OnClick="goBackLink_Click">(go back to departments)</asp:LinkButton><br />
<br />
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID"
  Width="100%" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowDeleting="grid_RowDeleting" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating">
  <Columns>
    <asp:BoundField DataField="Name" HeaderText="Category Name" SortExpression="Name" />
    <asp:TemplateField HeaderText="Category Description" SortExpression="Description">
      <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'>
        </asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" Text='<%# Bind("Description") %>'
          Height="70px" Width="350px" />
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
      <ItemTemplate>
        <asp:HyperLink runat="server" ID="link" NavigateUrl='<%# "../CatalogAdmin.aspx?DepartmentID=" + Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + Eval("CategoryID")%>'
          Text="View Products">
        </asp:HyperLink>
      </ItemTemplate>
    </asp:TemplateField>
    <asp:CommandField ShowEditButton="True" />
    <asp:ButtonField CommandName="Delete" Text="Delete" />
  </Columns>
</asp:GridView>
<br />
<span class="AdminPageText">Create a new category in this department:</span>
<table class="AdminPageText" cellspacing="0">
  <tr>
    <td valign="top" width="100">
      Name:</td>
    <td>
      <asp:TextBox CssClass="AdminPageText" ID="newName" runat="server" Width="400px" />
    </td>
  </tr>
  <tr>
    <td valign="top" width="100">
      Description:</td>
    <td>
      <asp:TextBox CssClass="AdminPageText" ID="newDescription" runat="server" Width="400px"
        Height="70px" TextMode="MultiLine" />
    </td>
  </tr>
</table>
<asp:Button ID="createCategory" Text="Create Category" runat="server" CssClass="Button" OnClick="createCategory_Click" />
