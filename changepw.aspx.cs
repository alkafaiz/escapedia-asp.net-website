using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML_ASSIGNMENT
{
    public partial class changepw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/vendor.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("vendor");
            StringBuilder html1 = new StringBuilder();
            html1.Append("<div class='alert alert-warning alert-dismissible' role='alert'>");
            html1.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'>");
            html1.Append("<span aria-hidden='true'>&times;</span></button>");

            if (txtOldPw.Text == "" || txtNewPw.Text == "" || txtConfPw.Text == "")
            {
                html1.Append("<strong>Sorry,</strong> the field must not be empty. ");
                html1.Append("</div>");
                alert1.Controls.Add(new Literal { Text = html1.ToString() });
            }
            else
            {
                for (int i = 0; i <= records.Count - 1; i++)
                {
                    if (records[i].ChildNodes.Item(0).InnerText.Trim() == Session["vendorID"].ToString())
                    {
                        //validation
                        if (txtOldPw.Text == records[i].ChildNodes.Item(8).InnerText.Trim())
                        {
                            if (txtNewPw.Text == txtConfPw.Text)
                            {
                                records[i].ChildNodes.Item(8).InnerText = txtNewPw.Text;
                                xmldoc.Save(Server.MapPath("vendor.xml"));
                                //save to db
                                SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
                                try
                                {
                                    con.Open();
                                    string query = "UPDATE Partner SET password=@password WHERE vendorID= '" + Convert.ToInt32(Session["vendorID"].ToString()) + "' ";
                                    SqlCommand cmd = new SqlCommand(query, con);
                                    cmd.Parameters.AddWithValue("@password", records[i].ChildNodes.Item(8).InnerText);

                                    cmd.ExecuteNonQuery();
                                    //Console.Write("sucesssssssssss");
                                    con.Close();

                                }

                                catch (Exception ex)
                                {
                                    Response.Write("Error: " + ex.ToString());
                                    //Console.Write("faiill");
                                }
                                Response.Redirect("dashboard.aspx");
                                break;
                            }
                            else
                            {
                                html1.Append("<strong>Sorry,</strong> the new password didn't match. ");
                                html1.Append("</div>");
                                alert1.Controls.Add(new Literal { Text = html1.ToString() });
                            }
                        }
                        else
                        {
                            html1.Append("<strong>Sorry,</strong> the existing password you entered is wrong ");
                            html1.Append("</div>");
                            alert1.Controls.Add(new Literal { Text = html1.ToString() });
                        }


                    }
                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
}