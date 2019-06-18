using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Text;

namespace XML_ASSIGNMENT
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
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
            doc.Save(MapPath("~/vendor.xml"));*/
        }

        protected void btnRegist_Click(object sender, EventArgs e)
        {
            StringBuilder html1 = new StringBuilder();
            html1.Append("<div class='alert alert-warning alert-dismissible' role='alert'>");
            html1.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'>");
            html1.Append("<span aria-hidden='true'>&times;</span></button>");
            if (txtConfirmPw.Text == "" || txtEmail.Text == "" || txtPw.Text == "" || txtUname.Text == "")
            {
                html1.Append("<strong>Sorry,</strong> the field must not be empty. ");
                html1.Append("</div>");
                alert1.Controls.Add(new Literal { Text = html1.ToString() });
            }
            else
            {
                if (txtPw.Text == txtConfirmPw.Text)
                {
                    Random rnd = new Random();
                    int id = rnd.Next(999999, 10000000) + 1;

                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(Server.MapPath("~/vendor.xml"));
                    XmlNode node = xmldoc.SelectNodes("/NewDataSet/vendor")[0];

                    String nodata = "none";
                    XmlNode newnode = node.CloneNode(true);
                    newnode.SelectSingleNode("vendorID").InnerText = id.ToString();
                    newnode.SelectSingleNode("uname").InnerText = txtUname.Text;
                    newnode.SelectSingleNode("compName").InnerText = nodata;
                    newnode.SelectSingleNode("address").InnerText = nodata;
                    newnode.SelectSingleNode("city").InnerText = nodata;
                    newnode.SelectSingleNode("country").InnerText = nodata;
                    newnode.SelectSingleNode("email").InnerText = txtEmail.Text;
                    newnode.SelectSingleNode("phone").InnerText = nodata;
                    newnode.SelectSingleNode("password").InnerText = txtPw.Text;
                    xmldoc.DocumentElement.AppendChild(newnode);
                    xmldoc.Save(Server.MapPath("vendor.xml"));

                    //update database
                    SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");

                    try
                    {
                        con.Open();
                        //stop here, add nodata to db
                        string query = "INSERT INTO Partner (vendorID,uname,compName,address,city,country,email,phone,password) values (@vendorID,@uname,@compName,@address,@city,@country,@email,@phone,@password)";

                        SqlCommand cmd = new SqlCommand(query, con);


                        cmd.Parameters.AddWithValue("@vendorID", id);
                        cmd.Parameters.AddWithValue("@uname", txtUname.Text.Trim());
                        cmd.Parameters.AddWithValue("@compName", nodata);
                        cmd.Parameters.AddWithValue("@address", nodata);
                        cmd.Parameters.AddWithValue("@city", nodata);
                        cmd.Parameters.AddWithValue("@country", nodata);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", nodata);
                        cmd.Parameters.AddWithValue("@password", txtPw.Text.ToString().Trim());

                        cmd.ExecuteNonQuery();


                        con.Close();
                        Response.Write("XML File updated!");
                        Response.Redirect("login.aspx");
                    }

                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.ToString());
                    }
                    
                        
                }
                else
                {
                    html1.Append("<strong>Sorry,</strong> the password you entered didn't match. ");
                    html1.Append("</div>");
                    alert1.Controls.Add(new Literal { Text = html1.ToString() });
                }
            }
            

        }
    }
}