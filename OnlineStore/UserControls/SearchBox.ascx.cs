using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SearchBox : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't repopulate control on postbacks
    if (!IsPostBack)
    {
      // tie the search text box to the Go button
      Utilities.TieButton(this.Page, searchTextBox, goButton);
      // load search box controls' values
      string allWords = Request.QueryString["AllWords"];
      string searchString = Request.QueryString["Search"];
      if (allWords != null)
        allWordsCheckBox.Checked = (allWords.ToUpper() == "TRUE");
      if (searchString != null)
        searchTextBox.Text = searchString;
    }
  }

  // Perform the product search
  protected void goButton_Click(object sender, EventArgs e)
  {
    ExecuteSearch();
  }

  // Redirect to the search results page
  private void ExecuteSearch()
  {
    if (searchTextBox.Text.Trim() != "")
      Response.Redirect(Request.ApplicationPath +
                   "/Search.aspx?Search=" + searchTextBox.Text +
                   "&AllWords=" + allWordsCheckBox.Checked.ToString());
  }
}
