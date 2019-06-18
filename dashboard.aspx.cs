using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XML_ASSIGNMENT
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendorID"] != null)
            {
                
                
                lblvendorID.Text = Session["vendorID"].ToString();
                lblusername.Text = Session["uname"].ToString();
                lblCompanyName.Text = Session["compName"].ToString();
                lbladdress.Text = Session["address"].ToString();
                lblCity.Text = Session["city"].ToString();
                lblCountry.Text = Session["country"].ToString();
                lblEmail.Text = Session["email"].ToString();
                lblPhone.Text = Session["phone"].ToString();
                

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("home.aspx");
        }
    }
}