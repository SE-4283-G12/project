using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class ViewCategoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ErrorMessage"] = "";
                setCategoriesTable();
            }
        }
        public void setCategoriesTable()        // Display each of a users Categories
        {
            List<Models.EventModel.Category> allCategories = Session["UserCategories"] as List<Models.EventModel.Category>;
            if (allCategories != null)
            {
                StringBuilder rowsHtml = new StringBuilder();

                // empty table
                rowsHtml.Clear();

                // track task count
                //int count = 0;
                //tableRowCount.InnerHtml = "";
                //tableRowCount.InnerHtml = (count).ToString();


                foreach (Models.EventModel.Category category in allCategories)
                {

                    // for each task that passes filtering we want to adjust the count of tasks for view
                    //tableRowCount.InnerHtml = (++count).ToString();
                    // Generate HTML for each row
                    rowsHtml.Append("<tr OnClick=\"TableRowClicked()\" runat=\"server\">");
                    rowsHtml.Append("<td>").Append(category.getName()).Append("</td>");
                    rowsHtml.Append("</tr>");
                }

                //tableRowCount.InnerHtml += " Tasks";

                // Set the generated HTML to the tbody element
                categoryRows.InnerHtml = rowsHtml.ToString();
            }
        }
        protected void creatcategory_Click(object sender, EventArgs e)      // Create new user category
        {
            if (categoryname.Text.Length > 0 && isNewCategoryUnique(categoryname.Text))
            {
                ((UserAccount)HttpContext.Current.Session["UserAccount"]).createNewUserAccountCategory(categoryname.Text);
                ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserCategoriesData();
                setCategoriesTable();
            }
            else
            {
                ViewState["ErrorMessage"] = "Invalid Category Name";
            }
            errorCheck();
        }

        public bool isNewCategoryUnique(string newCategoryName)
        {
            // check all existing categorys
            List<Category> categories = ((List<Category>)HttpContext.Current.Session["UserCategories"]);
            foreach (Category category in categories)
            {
                if (category.getName() == newCategoryName) return false;
            }
            return true;
        }

        public void errorCheck()
        {
            if (ViewState["ErrorMessage"].ToString() == "Invalid Category Name")
            {
                // Display Error Message
                errorMessage.Text = ViewState["ErrorMessage"].ToString();
                errorMessage.CssClass = "error_message_label";
            }
        }
    }
}
