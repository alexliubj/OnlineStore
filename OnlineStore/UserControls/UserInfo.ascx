<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserInfo" %>
<table cellspacing="0" border="0" class="UserInfoContent" style="width: 185px">
  <tr>
    <td class="UserInfoHead">
      User Info</td>
  </tr>
  <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
      <tr>
        <td>
          <span class="UserInfoText">Please log in.</span>
        </td>
      </tr>
      <tr>
        <td>
          &nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="UserInfoLink" />
          &nbsp;
        </td>
      </tr>
    </AnonymousTemplate>
    <RoleGroups>
      <asp:RoleGroup Roles="Administrators">
        <ContentTemplate>
          <tr>
            <td>
              <asp:LoginName ID="LoginName2" runat="server" FormatString="Welcome <b>{0}</b>."
                CssClass="UserInfoText" />
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
                <asp:LoginStatus ID="LoginStatus2" runat="server" CssClass="UserInfoLink" />
              &nbsp;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
                <a class="UserInfoLink" href="CatalogAdmin.aspx">Catalog Admin</a>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
                <a class="UserInfoLink" href="ShoppingCartAdmin.aspx">Shopping Cart Admin</a>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
                <a class="UserInfoLink" href="OrdersAdmin.aspx">Orders Admin</a> 
              &nbsp;
            </td>
          </tr>
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
  </asp:LoginView>
</table>
