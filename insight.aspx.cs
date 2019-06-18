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
    public partial class insight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendorID"] != null)
            {
                try
                {
                    XmlDocument xmldoc1 = new XmlDocument();
                    xmldoc1.Load(Server.MapPath("~/transaction.xml"));
                    XmlElement root = xmldoc1.DocumentElement;
                    root.RemoveAll();
                }
                catch { }
                DataSet ds = new DataSet();
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=EscapediaDB;Integrated Security=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from TrRecord", con);
                    da.Fill(ds, "transaction");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Not able to connect to DB')", true);
                }
                XmlDataDocument doc = new XmlDataDocument(ds);
                doc.Save(MapPath("~/transaction.xml"));

                lblvendorID.Text = Session["vendorID"].ToString();                
                lblCompanyName.Text = Session["compName"].ToString();
                lbladdress.Text = Session["address"].ToString();
                lblCity.Text = Session["city"].ToString();
                lblCountry.Text = Session["country"].ToString();
                lblEmail.Text = Session["email"].ToString();
                lblPhone.Text = Session["phone"].ToString();

                //get to insight
                List<String> months = getmonths(Session["vendorID"].ToString());
                List<String> IDS = getPackID(Session["vendorID"].ToString());
                StringBuilder html1 = new StringBuilder();
                if (IDS.Count != 0)
                {
                    for (int i = 0; i < months.Count; i++)
                    {
                        html1.Append("<div class='col-sm-6'>");
                        html1.Append("<div class='progress-bars'>");
                        html1.Append("<h5 class=uppercase'>");
                        html1.Append(months[i].ToString());
                        html1.Append("</h5>");
                        double totalAm = 0;
                        double totqty = TotalTrQtybyMonth(Session["vendorID"].ToString(), months[i].ToString());
                        for (int z = 0; z < IDS.Count; z++)
                        {
                            String ss = getTitle(IDS[z].ToString());
                            html1.Append(ss);
                            html1.Append("<div class='progress progress-1'>");
                            html1.Append("<div class='progress-bar' data-progress='");                          
                            double packqty = GettrQty(IDS[z].ToString(), months[i].ToString());
                            String percen = getPercentage(packqty, totqty);
                            html1.Append(percen);
                            html1.Append("'");
                            html1.Append("<span class='title'>");                         
                            html1.Append("Total: " + packqty.ToString());
                            html1.Append("</span>");
                            html1.Append("</div></div>");
                            double price = getPrice(IDS[z].ToString());
                            double totprice = price * packqty;
                            totalAm += totprice;
                        }
                        html1.Append("</div>");
                        html1.Append("<h5 class='uppercase'>Total Amount: RM ");
                        html1.Append(totalAm.ToString());
                        html1.Append("</h5>");
                        html1.Append("<hr /></div>");
                    }

                    bsinsight.Controls.Add(new Literal { Text = html1.ToString() });
                }
                else { lblNone.Visible = true; }
                
            }
        }

        private List<String> getPackID(String vendorID)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/package.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("package");
            List<String> IDs = new List<string>();
            for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
            {
                if (records[i].ChildNodes.Item(7).InnerText.Trim() == vendorID)
                {
                    if (IDs.Contains(records[i].ChildNodes.Item(0).InnerText.Trim()) == false)
                    {
                        IDs.Add(records[i].ChildNodes.Item(0).InnerText.Trim());
                    }
                }
            }
            return IDs;
        }

        private double getPrice(String packageID)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/package.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("package");
            string str;
            double price = 0;
            for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
            {
                if (records[i].ChildNodes.Item(0).InnerText.Trim() == packageID)
                {
                    price += Convert.ToDouble(records[i].ChildNodes.Item(6).InnerText.Trim());
                    break;
                }
            }
            return price;
        }

        //private String getTotalAmm(String packageID)
        //{
        //    XmlDocument xmldoc = new XmlDocument();
        //    xmldoc.Load(Server.MapPath("~/package.xml"));

        //    XmlNodeList records = xmldoc.GetElementsByTagName("package");
        //    string str;
        //    double price = 0;
        //    for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
        //    {
        //        if (records[i].ChildNodes.Item(0).InnerText.Trim() == packageID)
        //        {
        //            price += Convert.ToDouble(records[i].ChildNodes.Item(6).InnerText.Trim());
        //            break;
        //        }

        //    }
        //    return price;
        //}


        private String getTitle(String packageID)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/package.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("package");
            string tit="";            
            for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
            {
                if (records[i].ChildNodes.Item(0).InnerText.Trim() == packageID)
                {
                    tit += records[i].ChildNodes.Item(1).InnerText.Trim();
                    break;
                }
            }
            return tit;
        }
        private List<String> getmonths(String vendorID)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/transaction.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("transaction");
            List<String> months = new List<string>();            
            for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
            {                
                if (records[i].ChildNodes.Item(1).InnerText.Trim() == vendorID)
                {
                    if (months.Contains(records[i].ChildNodes.Item(5).InnerText.Trim()) == false){
                        months.Add(records[i].ChildNodes.Item(5).InnerText.Trim());
                    }                    
                }
            }
            return months;
        }

        private double GettrQty(String packageID, String month)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/transaction.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("transaction");
            double qty = 0;
            for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
            {
                if (records[i].ChildNodes.Item(2).InnerText.Trim() == packageID)
                {
                    if (records[i].ChildNodes.Item(5).InnerText.Trim() == month)
                    {
                        qty += 1;
                    }
                }
            }
            return qty;
        }
        private double TotalTrQtybyMonth(String vendorID, String month)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/transaction.xml"));
            XmlNodeList records = xmldoc.GetElementsByTagName("transaction");
            double qty = 0;
            for (int i = 0; i <= records.Count - 1; i++)  // this is for 3 cols sample
            {
                if (records[i].ChildNodes.Item(1).InnerText.Trim() == vendorID &&
                    records[i].ChildNodes.Item(5).InnerText.Trim() == month)
                {
                    qty += 1;
                }
            } return qty;
        }

        private String getPercentage(double packQty, double totalQtybyMonth)
        {
            double perc = packQty / totalQtybyMonth * 100;
            return perc.ToString();
        }

    }
}