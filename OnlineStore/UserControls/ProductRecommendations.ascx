<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRecommendations.ascx.cs" Inherits="ProductRecommendations" %>
<asp:Label ID="recommendationsHeader" runat="server" CssClass="RecommendationHead" />
<asp:DataList ID="list" runat="server">
  <ItemTemplate>
    <table cellpadding="0" cellspacing="0">
      <tr>
        <td width="170px">
          <a class="RecommendationLink" href='Product.aspx?ProductID=<%# Eval("ProductID") %>'>
            <%# Eval("Name") %>
          </a>  
        </td>
        <td class="RecommendationText" valign="top">
          <%# Eval("Description") %>
        </td>
      </tr>
    </table>
  </ItemTemplate>
</asp:DataList>
