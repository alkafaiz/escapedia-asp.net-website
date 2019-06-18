using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XML_ASSIGNMENT
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendorID"] != null)
            {
                lblUser.Text = "Hallo " + Session["uname"].ToString() + " ";
                lblUsernm.Text = Session["compName"].ToString();

                


            }
        }
    }
}