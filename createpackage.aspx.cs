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
    public partial class createpackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder html1 = new StringBuilder();
            html1.Append("<div class='alert alert-warning alert-dismissible' role='alert'>");
            html1.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'>");
            html1.Append("<span aria-hidden='true'>&times;</span></button>");
            if (txtTitle.Text == "" || txtDest.Text == "" || txtDesc.Text == ""
                || txtDur.Text == "" || txtType.Text == "" || txtPrice.Text == "")
            {
                html1.Append("<strong>Sorry,</strong> the field must not be empty. ");
                html1.Append("</div>");
                alert1.Controls.Add(new Literal { Text = html1.ToString() });
            }
            else
            {
                Guid obj = Guid.NewGuid();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Server.MapPath("~/package.xml"));
                XmlNode node = xmldoc.SelectNodes("/NewDataSet/package")[0];
                XmlNode newnode = node.CloneNode(true);
                // update element values for the new node
                newnode.SelectSingleNode("packageID").InnerText = obj.ToString();
                newnode.SelectSingleNode("title").InnerText = txtTitle.Text;
                newnode.SelectSingleNode("destination").InnerText = txtDest.Text;
                newnode.SelectSingleNode("descr").InnerText = txtDesc.Text;
                newnode.SelectSingleNode("duration").InnerText = txtDur.Text;
                newnode.SelectSingleNode("type").InnerText = txtType.Text;
                newnode.SelectSingleNode("price").InnerText = txtPrice.Text;
                newnode.SelectSingleNode("vendorID").InnerText = Session["vendorID"].ToString();
                xmldoc.DocumentElement.AppendChild(newnode);
                xmldoc.Save(Server.MapPath("package.xml"));

                //update database
                SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");

                try
                {
                    con.Open();

                    string query = "INSERT INTO package (packageID,title,destination,descr,duration,type,price,vendorID) values (@packageID,@title,@destination,@descr,@duration,@type,@price,@vendorID)";

                    SqlCommand cmd = new SqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@packageID", obj.ToString());
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@destination", txtDest.Text);
                    cmd.Parameters.AddWithValue("@descr", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@duration", txtDur.Text);
                    cmd.Parameters.AddWithValue("@type", txtType.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@vendorID", Session["vendorID"].ToString());

                    cmd.ExecuteNonQuery();


                    con.Close();
                    Response.Write("XML File updated!");
                    Response.Redirect("packages.aspx");
                }

                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.ToString());
                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("packages.aspx");
        }
    }
}