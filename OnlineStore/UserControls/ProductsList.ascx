<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsList.ascx.cs"
  Inherits="ProductsList" %>
<asp:Label ID="pagingLabel" runat="server" CssClass="PagingText" Visible="false" />
&nbsp;&nbsp;
<asp:HyperLink ID="previousLink" runat="server" CssClass="PagingText" Visible="false">Previous</asp:HyperLink>
&nbsp;&nbsp;
<asp:HyperLink ID="nextLink" runat="server" CssClass="PagingText" Visible="false">Next</asp:HyperLink>&nbsp;&nbsp;
<asp:DropDownList ID="dropDown" runat="server" 
    onselectedindexchanged="dropDown_SelectedIndexChanged" Visible="False" AutoPostBack="true">
<asp:ListItem>Price: Low - High</asp:ListItem>
<asp:ListItem>Price: High - Low</asp:ListItem>
</asp:DropDownList>
<asp:DataList ID="list" Runat="server" RepeatColumns="3" 
    EnableViewState="False" OnItemCommand="list_ItemCommand" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
    ForeColor="Black" GridLines="Vertical" RepeatDirection="Horizontal">
    <AlternatingItemStyle BackColor="White" />
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <ItemStyle BackColor="#F7F7DE" />
  <ItemTemplate>
    <table cellPadding="0" align="left">
      <tr height="105">
        <td align="center" width="110">
          <a href='Product.aspx?ProductID=<%# Eval("ProductID")%>'>
            <img width="100" src='ProductImages/<%# Eval("Thumbnail") %>' border="0"/>
          </a>
        </td>
        <td vAlign="top" width="250">
          <a class="ProductName" href='Product.aspx?ProductID=<%# Eval("ProductID")%>'>
            <%# Eval("Name") %>
          </a>
          <br/>
          <span class="ProductDescription">
            <%# Eval("Description") %>
            <br/><br/>
            Price: 
          </span>
          <span class="ProductPrice">
            <%# Eval("Price", "{0:c}") %>
          </span>
          <br />
          <asp:Button ID="addToCartButton" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("ProductID") %>' CssClass="SmallButtonText"/>
        </td>
      </tr>
    </table>
  </ItemTemplate>
    <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
</asp:DataList>
