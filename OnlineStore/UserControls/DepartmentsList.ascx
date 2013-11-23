<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsList.ascx.cs" Inherits="DepartmentsList" %>
<asp:DataList ID="list" runat="server" Width="600px" 
    CssClass="DepartmentListContent" RepeatColumns = "5">
  <ItemTemplate>
 
    <asp:HyperLink    
         
      ID="HyperLink1" 
      Runat="server" 
      NavigateUrl='<%# "../Catalog.aspx?DepartmentID=" + Eval("DepartmentID")%>'
      Text='<%# Eval("Name") %>'
      ToolTip='<%# Eval("Description") %>'
      CssClass='<%# Eval("DepartmentID").ToString() == Request.QueryString["DepartmentID"] ? "DepartmentSelected" : "DepartmentUnselected" %>'>
    
    </asp:HyperLink>
    &nbsp; 
 </ItemTemplate>
  <HeaderTemplate>

  </HeaderTemplate>
  <HeaderStyle CssClass="DepartmentListHead" />
</asp:DataList>
