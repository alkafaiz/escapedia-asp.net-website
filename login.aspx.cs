using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML_ASSIGNMENT
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    XmlDocument xmldoc1 = new XmlDocument();
                    xmldoc1.Load(Server.MapPath("~/vendor.xml"));
                    XmlElement root = xmldoc1.DocumentElement;
                    root.RemoveAll();
                }
                catch { }
                DataSet ds = new DataSet();
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Partner", con);
                    da.Fill(ds, "vendor");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Not able to connect to DB')", true);
                }
                XmlDataDocument doc = new XmlDataDocument(ds);
                doc.Save(MapPath("~/vendor.xml"));
            }            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool granted = false;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/vendor.xml"));
            StringBuilder html1 = new StringBuilder();
            html1.Append("<div class='alert alert-warning alert-dismissible' role='alert'>");
            html1.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'>");
            html1.Append("<span aria-hidden='true'>&times;</span></button>");

            XmlNodeList records = xmldoc.GetElementsByTagName("vendor");
            string str;

            if (txtUname.Text == "" || txtPw.Text == "" )
            {
                html1.Append("<strong>Sorry,</strong> the field must not be empty. ");
                html1.Append("</div>");
                alert1.Controls.Add(new Literal { Text = html1.ToString() });
            }
            else
            {
                for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
                {
                    if (records[i].ChildNodes.Item(1).InnerText.Trim() == txtUname.Text)
                    {
                        if (txtPw.Text == records[i].ChildNodes.Item(8).InnerText.Trim())
                        {
                            Response.Write("login success!");
                            Session["vendorID"] = records[i].ChildNodes.Item(0).InnerText.Trim();
                            Session["uname"] = records[i].ChildNodes.Item(1).InnerText.Trim();
                            Session["compName"] = records[i].ChildNodes.Item(2).InnerText.Trim();
                            Session["address"] = records[i].ChildNodes.Item(3).InnerText.Trim();
                            Session["city"] = records[i].ChildNodes.Item(4).InnerText.Trim();
                            Session["country"] = records[i].ChildNodes.Item(5).InnerText.Trim();
                            Session["email"] = records[i].ChildNodes.Item(6).InnerText.Trim();
                            Session["phone"] = records[i].ChildNodes.Item(7).InnerText.Trim();
                            Session["password"] = records[i].ChildNodes.Item(8).InnerText.Trim();

                            granted = true;
                            Response.Redirect("dashboard.aspx");
                            break;
                        }
                        else
                        {
                            granted = false;
                            //html1.Append("<strong>Sorry,</strong> you have entered wrong password. ");
                            //html1.Append("</div>");
                            //alert1.Controls.Add(new Literal { Text = html1.ToString() });
                            //break;
                        }

                    }
                    else
                    {
                        granted = false;
                        //html1.Append("<strong>Sorry,</strong> you have not been registered. ");
                        //html1.Append("</div>");
                        //alert1.Controls.Add(new Literal { Text = html1.ToString() });
                    }

                }
            }

            if(granted == false)
            {
                html1.Append("<strong>Sorry,</strong> you have entered wrong password or username. ");
                html1.Append("</div>");
                alert1.Controls.Add(new Literal { Text = html1.ToString() });
            }

        }
    }
}