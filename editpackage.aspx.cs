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
    public partial class editpackage : System.Web.UI.Page
    {
        String packageID="";

        protected void Page_Load(object sender, EventArgs e)
        {
            packageID += Request.QueryString["id"];
            if (!IsPostBack)
            {
                
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Server.MapPath("~/package.xml"));

                XmlNodeList records = xmldoc.GetElementsByTagName("package");
                string str;
                for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
                {
                    if (records[i].ChildNodes.Item(0).InnerText.Trim() == packageID)
                    {
                        txtID.Text = records[i].ChildNodes.Item(0).InnerText.Trim();
                        txtTitle.Text = records[i].ChildNodes.Item(1).InnerText.Trim();
                        txtDest.Text = records[i].ChildNodes.Item(2).InnerText.Trim();
                        txtDesc.Text = records[i].ChildNodes.Item(3).InnerText.Trim();
                        txtDur.Text = records[i].ChildNodes.Item(4).InnerText.Trim();
                        if (records[i].ChildNodes.Item(5).InnerText.Trim() == "Personal")
                        {
                            txtType.SelectedIndex = 0;
                        }
                        else { txtType.SelectedIndex = 1; }

                        txtPrice.Text = records[i].ChildNodes.Item(6).InnerText.Trim();
                    }

                }

            }
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
                //save to xml
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Server.MapPath("~/package.xml"));
                XmlNodeList records = xmldoc.GetElementsByTagName("package");
                for (int i = 0; i <= records.Count - 1; i++)
                {
                    if (records[i].ChildNodes.Item(0).InnerText.Trim() == packageID)
                    {
                        records[i].ChildNodes.Item(1).InnerText = txtTitle.Text;
                        records[i].ChildNodes.Item(2).InnerText = txtDest.Text;
                        records[i].ChildNodes.Item(3).InnerText = txtDesc.Text;
                        records[i].ChildNodes.Item(4).InnerText = txtDur.Text.ToString();
                        records[i].ChildNodes.Item(5).InnerText = txtType.SelectedValue;
                        records[i].ChildNodes.Item(6).InnerText = txtPrice.Text.ToString();                       
                        xmldoc.Save(Server.MapPath("package.xml"));
                        //save to db
                        SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
                        try
                        {
                            con.Open();
                            string query = "UPDATE package SET title=@title, destination=@destination, descr=@descr, duration=@duration, type=@type, price=@price WHERE packageID= '" + packageID + "' ";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@title", records[i].ChildNodes.Item(1).InnerText);
                            cmd.Parameters.AddWithValue("@destination", records[i].ChildNodes.Item(2).InnerText);
                            cmd.Parameters.AddWithValue("@descr", records[i].ChildNodes.Item(3).InnerText);
                            cmd.Parameters.AddWithValue("@duration", Convert.ToInt32(records[i].ChildNodes.Item(4).InnerText));
                            cmd.Parameters.AddWithValue("@type", records[i].ChildNodes.Item(5).InnerText);
                            cmd.Parameters.AddWithValue("@price", records[i].ChildNodes.Item(6).InnerText);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //btnCancel.Text = txtTitle.Text;
                            Response.Redirect("packages.aspx");
                        }

                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.ToString());
                        }

                        break;
                    }
                    else { }

                }

            }

            // Response.Redirect("packages.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("packages.aspx");
            

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/package.xml"));

            XmlNodeList records = xmldoc.GetElementsByTagName("package");

            for (int i = 0; i <= records.Count - 1; i++)
            {
                if (records[i].ChildNodes.Item(0).InnerText.Trim() == packageID)
                {
                    XmlNode deleteNote = records[i];
                    records[i].ParentNode.RemoveChild(deleteNote);

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Deleting....')", true);
                    xmldoc.Save(Server.MapPath("package.xml"));
                    //
                    break;
                }

            }

            SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
            try
            {
                con.Open();                
                SqlCommand cmd = new SqlCommand("DELETE FROM package WHERE packageID= '" + packageID + "' ", con);          
                cmd.ExecuteNonQuery();
                con.Close();          
            }

            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
            Response.Redirect("packages.aspx");

        }
        private void addrecordtr(int vendorID, String pID, String month)
        {
            //update database
            SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
            Guid obj = Guid.NewGuid();
            Guid Cid = Guid.NewGuid();
            Random rnd = new Random();
            int datep = rnd.Next(1, 31);
            try
            {
                con.Open();
                string query = "INSERT INTO TrRecord (traID,vendorID,packageID,custID,date,month,year) values (@traID,@vendorID,@packageID,@custID,@date,@month,@year)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@traID", obj.ToString());
                cmd.Parameters.AddWithValue("@vendorID", vendorID);
                cmd.Parameters.AddWithValue("@packageID", pID);
                cmd.Parameters.AddWithValue("@custID", Cid);
                cmd.Parameters.AddWithValue("@date", datep);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", 2018);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }

        protected void btnMockUp_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num1 = rnd.Next(3, 15);
            int num2 = rnd.Next(3, 15);
            int num3 = rnd.Next(3, 15);
            int num4 = rnd.Next(3, 15);
            for (int i = 0; i < num1; i++)
            {
                addrecordtr(Convert.ToInt32(Session["vendorID"].ToString()), packageID, "October");
            }
            for (int i = 0; i < num2; i++)
            {
                addrecordtr(Convert.ToInt32(Session["vendorID"].ToString()), packageID, "September");
            }
            for (int i = 0; i < num2; i++)
            {
                addrecordtr(Convert.ToInt32(Session["vendorID"].ToString()), packageID, "November");
            }
            for (int i = 0; i < num2; i++)
            {
                addrecordtr(Convert.ToInt32(Session["vendorID"].ToString()), packageID, "December");
            }
        }
    }
}