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
    public partial class packages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
                try
                {
                    XmlDocument xmldoc1 = new XmlDocument();
                    xmldoc1.Load(Server.MapPath("~/package.xml"));
                    XmlElement root = xmldoc1.DocumentElement;
                    root.RemoveAll();
                }
                catch { }

                DataSet ds = new DataSet();
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from package", con);
                    da.Fill(ds, "package");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Not able to connect to DB')", true);
                }
                XmlDataDocument doc = new XmlDataDocument(ds);
                doc.Save(MapPath("~/package.xml"));

                //checking if it has package
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Server.MapPath("~/package.xml"));

                XmlNodeList records = xmldoc.GetElementsByTagName("package");
                string str;
            bool hasPackage = false;
                /*
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                var dataView = ((DataTable)this.GridView1.DataSource).DefaultView;*/
                //dataView.RowFilter = "(vendorID = '" + Session["vendorID"].ToString() + "')";
                StringBuilder html = new StringBuilder();
                for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
                {
                    if (records[i].ChildNodes.Item(7).InnerText.Trim() == Session["vendorID"].ToString())
                    {
                        //Response.Write(records[i].ChildNodes.Item(1).InnerText.Trim());
                        html.Append("<div class='col-md-6'>");
                        html.Append("<div class='image-caption cast-shadow mb-xs-32'>");
                        html.Append("<img alt='");
                        html.Append("Captioned Image'");
                        html.Append(" src='img/");
                        html.Append("trip2japan.jpg");
                        html.Append("'/>");

                        html.Append("<div class='caption'>");
                        html.Append("<p><strong>Package: </strong>");
                        html.Append(records[i].ChildNodes.Item(1).InnerText.Trim());
                        html.Append("</p></div>");
                        html.Append("</div><br />");
                        html.Append("<a class='btn' href='editpackage.aspx?id=");
                        html.Append(records[i].ChildNodes.Item(0).InnerText.Trim());
                        html.Append("'>Edit</a>");
                        html.Append("</div>");
                    hasPackage = true;
                    }
                    else
                    {
                        
                    }

                }
                packagesVendor.Controls.Add(new Literal { Text = html.ToString() });
            if (hasPackage == false) { lblNone.Visible = true; }
            else { lblNone.Visible = false; }
            //}

            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("home.aspx");
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
                string query = "INSERT INTO Transaction (transactionID,vendorID,packageID,customerID,date,month,year) values (@transactionID,@vendorID,@packageID,@customerID,@date,@month,@year)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@transactionID", obj.ToString());
                cmd.Parameters.AddWithValue("@vendorID", vendorID);
                cmd.Parameters.AddWithValue("@packageID", pID);
                cmd.Parameters.AddWithValue("@customerID", Cid);
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
    }
}