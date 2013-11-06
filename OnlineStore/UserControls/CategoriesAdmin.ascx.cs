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
using OnlineStoreDAL;
using OnlineStoreDAL.Models;
using OnlineStoreBLO;
public partial class CategoriesAdmin : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Load the grid only the first time the page is loaded
    if (!Page.IsPostBack)
    {
      // Load the categories grid
      BindGrid();
      // Get DepartmentID from the query string
      string departmentId = Request.QueryString["DepartmentID"];
      // Obtain the department's name
      DepartmentDetails dd = CatalogBLO.GetDepartmentDetails(departmentId);
      string departmentName = dd.Name;
      // Set controls' properties
      statusLabel.ForeColor = System.Drawing.Color.Red;
      locationLabel.Text = "Displaying categories for department <b> "
        + departmentName + "</b>";
    }
  }

  // Populate the GridView with data
  private void BindGrid()
  {
    // Get DepartmentID from the query string
    string departmentId = Request.QueryString["DepartmentID"];
    // Get a DataTable object containing the categories
    grid.DataSource = CatalogBLO.GetCategoriesInDepartment(departmentId);
    // Bind the data grid to the data source
    grid.DataBind();
  }

  // Enter row into edit mode
  protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
  {
    // Set the row for which to enable edit mode
    grid.EditIndex = e.NewEditIndex;
    // Set status message 
    statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
    // Reload the grid
    BindGrid();
  }

  // Cancel edit mode
  protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
  {
    // Cancel edit mode
    grid.EditIndex = -1;
    // Set status message
    statusLabel.Text = "Editing canceled";
    // Reload the grid
    BindGrid();
  }

  // Update row
  protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
  {
    // Retrieve updated data
    string id = grid.DataKeys[e.RowIndex].Value.ToString();
    string name = ((TextBox)grid.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
    string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
    // Execute the update command
    bool success = CatalogBLO.UpdateCategory(id, name, description);
    // Cancel edit mode
    grid.EditIndex = -1;
    // Display status message
    statusLabel.Text = success ? "Update successful" : "Update failed";
    // Reload the grid
    BindGrid();
  }

  // Delete a record
  protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
  {
    // Get the ID of the record to be deleted
    string id = grid.DataKeys[e.RowIndex].Value.ToString();
    // Execute the delete command
    bool success = CatalogBLO.DeleteCategory(id);
    // Cancel edit mode
    grid.EditIndex = -1;
    // Display status message
    statusLabel.Text = success ? "Delete successful" : "Delete failed";
    // Reload the grid
    BindGrid();
  }

  // Create a new category
  protected void createCategory_Click(object sender, EventArgs e)
  {
    // Get DepartmentID from the query string
    string departmentId = Request.QueryString["DepartmentID"];
    // Execute the insert command
    bool success = CatalogBLO.CreateCategory(departmentId, newName.Text, newDescription.Text);
    // Display results
    statusLabel.Text = success ? "Insert successful" : "Insert failed";
    // Reload the grid
    BindGrid();
  }

  // Redirect to the department's page
  protected void goBackLink_Click(object sender, EventArgs e)
  {
    Response.Redirect(Request.ApplicationPath + "/CatalogAdmin.aspx");
  }
}
