<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsAdmin.ascx.cs" Inherits="DepartmentsAdmin" %>
<asp:Label ID="statusLabel" runat="server" CssClass="AdminPageText" Text="Departments Loaded"></asp:Label><br />
<br />
<asp:Label ID="locationLabel" runat="server" CssClass="AdminPageText" Text="These are your departments:"></asp:Label><br />
<br />
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="DepartmentID" Width="100%" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowDeleting="grid_RowDeleting" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating">
  <Columns>
    <asp:BoundField DataField="Name" HeaderText="Department Name" SortExpression="Name" />
    <asp:TemplateField HeaderText="Department Description" SortExpression="Description">
      <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>' Height="70px" TextMode="MultiLine" Width="350px"></asp:TextBox>
      </EditItemTemplate>
    </asp:TemplateField>
    <asp:HyperLinkField DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="../CatalogAdmin.aspx?DepartmentID={0}"
      Text="View Categories" />
    <asp:CommandField ShowEditButton="True" />
    <asp:ButtonField CommandName="Delete" Text="Delete" />
  </Columns>
</asp:GridView>
<br />
<span class="AdminPageText">Create a new department:</span>
<table class="AdminPageText" cellspacing="0">
  <tr>
    <td valign="top" width="100">Name:
    </td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newName" Runat="server" 
Width="400px" />      
    </td>
  </tr>
  <tr>
    <td valign="top" width="100">Description:
    </td>
    <td>
      <asp:TextBox cssClass="AdminPageText" ID="newDescription" Runat="server" Width="400px" Height="70px" TextMode="MultiLine"/>
    </td>
  </tr>
</table>
<asp:Button ID="createDepartment" Text="Create Department" Runat="server" 
CssClass="Button" OnClick="createDepartment_Click" />
