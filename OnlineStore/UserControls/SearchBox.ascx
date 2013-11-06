<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="SearchBox" %>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
  <tr>
    <td class="SearchBoxHead">
      Search the Catalog
    </td>
  </tr>
  <tr>
    <td class="SearchBoxContent">
      <asp:TextBox ID="searchTextBox" Runat="server" Width="128px" CssClass="SearchBox" BorderStyle="Dotted" MaxLength="100" Height="16px" />
      <asp:Button ID="goButton" Runat="server" CssClass="SearchBox" Text="Go!" Width="36px" Height="21px" OnClick="goButton_Click" /><br />
      <asp:CheckBox ID="allWordsCheckBox" CssClass="SearchBox" Runat="server" Text="Search for all words" />
    </td>
  </tr>
</table>
