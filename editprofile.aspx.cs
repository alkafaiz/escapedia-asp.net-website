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
    public partial class editprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["vendorID"] != null)
                {


                    TextBox1.Text = Session["vendorID"].ToString();
                    TextBox2.Text = Session["uname"].ToString();
                    TextBox3.Text = Session["compName"].ToString();
                    TextBox4.Text = Session["address"].ToString();
                    TextBox5.Text = Session["city"].ToString();
                    TextBox6.Text = Session["country"].ToString();
                    TextBox7.Text = Session["email"].ToString();
                    TextBox8.Text = Session["phone"].ToString();


                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder html1 = new StringBuilder();
            html1.Append("<div class='alert alert-warning alert-dismissible' role='alert'>");
            html1.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'>");
            html1.Append("<span aria-hidden='true'>&times;</span></button>");

            if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == ""
                || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == ""
                || TextBox8.Text == "")
            {
                html1.Append("<strong>Sorry,</strong> the field must not be empty. ");
                html1.Append("</div>");
                alert1.Controls.Add(new Literal { Text = html1.ToString() });
            }
            else
            {
                Session["uname"] = TextBox2.Text.ToString();
                Session["compName"] = TextBox3.Text.ToString();
                Session["address"] = TextBox4.Text;
                Session["city"] = TextBox5.Text.ToString();
                Session["country"] = TextBox6.Text;
                Session["email"] = TextBox7.Text;
                Session["phone"] = TextBox8.Text;
                //save to xml
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Server.MapPath("~/vendor.xml"));
                XmlNodeList records = xmldoc.GetElementsByTagName("vendor");
                for (int i = 0; i <= records.Count - 1; i++)
                {
                    if (records[i].ChildNodes.Item(0).InnerText.Trim() == Session["vendorID"].ToString())
                    {
                        records[i].ChildNodes.Item(1).InnerText = TextBox2.Text;
                        records[i].ChildNodes.Item(2).InnerText = TextBox3.Text;
                        records[i].ChildNodes.Item(3).InnerText = TextBox4.Text;
                        records[i].ChildNodes.Item(4).InnerText = TextBox5.Text;
                        records[i].ChildNodes.Item(5).InnerText = TextBox6.Text;
                        records[i].ChildNodes.Item(6).InnerText = TextBox7.Text;
                        records[i].ChildNodes.Item(7).InnerText = TextBox8.Text;
                        xmldoc.Save(Server.MapPath("vendor.xml"));
                        //save to db
                        SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
                        try
                        {
                            con.Open();
                            string query = "UPDATE Partner SET uname=@uname, compName=@compName, address=@address, city=@city, country=@country, email=@email, phone=@phone WHERE vendorID= '" + Convert.ToInt32(Session["vendorID"].ToString()) + "' ";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@uname", records[i].ChildNodes.Item(1).InnerText);
                            cmd.Parameters.AddWithValue("@compName", records[i].ChildNodes.Item(2).InnerText);
                            cmd.Parameters.AddWithValue("@address", records[i].ChildNodes.Item(3).InnerText);
                            cmd.Parameters.AddWithValue("@city", records[i].ChildNodes.Item(4).InnerText);
                            cmd.Parameters.AddWithValue("@country", records[i].ChildNodes.Item(5).InnerText);
                            cmd.Parameters.AddWithValue("@email", records[i].ChildNodes.Item(6).InnerText);
                            cmd.Parameters.AddWithValue("@phone", records[i].ChildNodes.Item(7).InnerText);
                            cmd.ExecuteNonQuery();
                            //Console.Write("sucesssssssssss");
                            con.Close();
                        }

                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.ToString());
                            //Console.Write("faiill");
                        }
                        break;
                    }

                }




                Response.Write(Session["phone"].ToString());
                Response.Redirect("dashboard.aspx");
            }
        }
    }
}