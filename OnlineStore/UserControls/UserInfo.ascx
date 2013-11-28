<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserInfo" %>
<div>
<table cellspacing="0" border="0" class="UserInfoContent" style="width: 185px">
<tr>
    <td class="UserInfoHead">
      User Info</td>
  </tr>
 </table> 
</div>
<div id="loginDiv" runat="server">
<table cellspacing="0" border="0" class="UserInfoContent" style="width: 185px">
<tr>
        <td>
          <span class="UserInfoText">Please log in.</span><asp:Button id="login" 
                runat="server" onclick="login_Click" Text="Login"/>
        </td>
      </tr>
 </table> 
</div>
<div id="divWelcome" runat="server">
<table cellspacing="0" border="0" class="UserInfoContent" style="width: 185px">
  <tr>
        <td>
          <span class="UserInfoText">Welcome </span><asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Button id="Button1" 
                runat="server" Text="Logout" onclick="Button1_Click"/>
        </td>
      </tr>
      </table>
</div>
<div id="testHide" runat="server">
<table cellspacing="0" border="0" class="UserInfoContent" style="width: 185px">
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
</table>
</div>