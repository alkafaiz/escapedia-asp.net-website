using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XML_ASSIGNMENT
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["vendorID"] != null)
                {
                    /*lblUser.Text = "Hallo " + Session["uname"].ToString() + " ";
                    btnLogin.Visible = false;
                    lblUser.Visible = true;*/
                    
                }
                else
                {

                }                
            }
        }

        /*protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }*/
    }
}