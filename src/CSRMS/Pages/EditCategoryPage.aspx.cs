using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class EditCategoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ErrorMessage"] = "";
                ViewState["categoryName"] = Request.QueryString["categoryName"];
                if (!string.IsNullOrEmpty(ViewState["categoryName"].ToString()))
                {
                    categoryname.Text = ViewState["categoryName"].ToString();
                }
                else
                {
                    Response.Redirect("ViewCategoryPage.aspx");
                }
            }
        }
        protected void EditCategoryBtn(object sender, EventArgs e)
        {
            if (categoryname.Text.Length > 0 && isNewCategoryUnique(categoryname.Text))
            {
                UserAccount.editUserAccountCateogry(ViewState["categoryName"].ToString(), categoryname.Text);
                ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserCategoriesData();
                ViewState["ErrorMessage"] = "";
                ViewState["categoryName"] = categoryname.Text;
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
            else
            {
                errorMessage.CssClass = "hidden";
            }
        }

        protected void DeleteCategoryBtn(object sender, EventArgs e)
        {
            foreach (Category category in ((List<Category>)HttpContext.Current.Session["UserCategories"]))
            {
                if (category.getName() == ViewState["categoryName"].ToString())
                {
                    UserAccount.deleteTaskCategory(category.getId());
                    ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserCategoriesData();
                    ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserTasksData();
                    Response.Redirect("ViewAllTaskPage.aspx");
                    break;
                }
            }

        }
    }
}
