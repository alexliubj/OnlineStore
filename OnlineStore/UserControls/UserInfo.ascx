<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserInfo" %>
<table cellspacing="0" border="0" width="200px" class="UserInfoContent">
  <tr>
    <td class="UserInfoHead">
      User Info</td>
  </tr>
  <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
      <tr>
        <td>
          <span class="UserInfoText">You are not logged in.</span>
        </td>
      </tr>
      <tr>
        <td>
          &nbsp;&raquo;
            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="UserInfoLink" />
          &nbsp;&laquo;
        </td>
      </tr>
    </AnonymousTemplate>
    <RoleGroups>
      <asp:RoleGroup Roles="Administrators">
        <ContentTemplate>
          <tr>
            <td>
              <asp:LoginName ID="LoginName2" runat="server" FormatString="You are logged in as <b>{0}</b>. "
                CssClass="UserInfoText" />
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;&raquo;
                <asp:LoginStatus ID="LoginStatus2" runat="server" CssClass="UserInfoLink" />
              &nbsp;&laquo;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;&raquo;
                <a class="UserInfoLink" href="CatalogAdmin.aspx">Catalog Admin</a>
              &nbsp;&laquo;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;&raquo;
                <a class="UserInfoLink" href="ShoppingCartAdmin.aspx">Shopping Cart Admin</a>
              &nbsp;&laquo;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;&raquo; 
                <a class="UserInfoLink" href="OrdersAdmin.aspx">Orders Admin</a> 
              &nbsp;&laquo;
            </td>
          </tr>
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
  </asp:LoginView>
</table>
