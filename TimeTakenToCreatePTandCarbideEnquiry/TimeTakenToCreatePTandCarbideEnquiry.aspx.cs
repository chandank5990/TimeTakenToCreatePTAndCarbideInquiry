using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace TimeTakenToCreatePTandCarbideEnquiry
{
    public partial class TimeTakenToCreatePTandCarbideEnquiry : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" || TextBox2.Text != "")
            {
                PendingOC2();
            }
            else
            {
                string script = "alert('Please Enter From Date, To Date. !!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnSubmit, this.GetType(), "Test", script, true);
            }
        }
        void PendingOC2()
        {
            //con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query;
            cmd.Connection = con;
            if (rdbtn1.Checked == true)
            {
                query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where (FecPed Between format(#" + TextBox1.Text + "#, \"dd/MM/yyyy\") And format(#" + TextBox2.Text + "#, \"dd/MM/yyyy\")) AND (Location = 1)";
            }
            else if (rdbtn2.Checked == true)
            {
                query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where (FecPed Between format(#" + TextBox1.Text + "#, \"dd/MM/yyyy\") And format(#" + TextBox2.Text + "#, \"dd/MM/yyyy\")) AND (Location = 2)";
            }
            else
            {
                query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where FecPed Between format(#" + TextBox1.Text + "#, \"dd/MM/yyyy\") And format(#" + TextBox2.Text + "#, \"dd/MM/yyyy\")";
            }
            //string query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where OcDate is Null";
            OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
            DataTable dtpending = new DataTable();
            ad.Fill(dtpending);
            //con.Close();
            dtpending.Columns.Add("Remarks", typeof(string));
            dtpending.Columns.Add("PODate", typeof(DateTime));
            dtpending.Columns.Add("DaystoMakePT", typeof(int));
            dtpending.Columns["Location"].SetOrdinal(7);

            dtpending.AcceptChanges();

            foreach (DataRow dr in dtpending.Rows)
            {

                if (Convert.ToInt32(dr[0]) == 0)
                {
                    dr.Delete();

                }
                else
                {
                    string date = dr["Cust_PO"].ToString().Substring(dr["Cust_PO"].ToString().LastIndexOf(' ') + 1);
                    //DateTime date2 = date.ToString(//DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string shortDate = date;
                    DateTime date3;
                    if (date.Length != 0)
                    {
                        DateTime date4 = Convert.ToDateTime(date);
                        string date5 = date4.ToShortDateString();
                        date3 = Convert.ToDateTime(date5);
                    }
                    else
                        date3 = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    dr["PODate"] = date3.ToShortDateString();
                    dr["DaystoMakePT"] = (Convert.ToDateTime(dr["Order_Date"]) - date3).TotalDays;
                }

            }

            dtpending.DefaultView.Sort = "PODate asc";
            GridView1.DataSource = dtpending;
            GridView1.DataBind();
            DataTable dtpricezero = new DataTable();
            Label4.Text = dtpending.Rows.Count.ToString();
        }
        void CarbideInquiry()
        {
            OleDbCommand cmd = new OleDbCommand();
            string query;
            cmd.Connection = con;
            if (rdbtn1.Checked == true)
            {
                 query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where FecPed Between (format(#" + TextBox1.Text + "#, \"dd/mm/yyyy\") And format(#" + TextBox2.Text + "#, \"dd/mm/yyyy\")) AND Location = 1";
            }
            else if (rdbtn2.Checked == true)
            {
                 query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where FecPed Between (format(#" + TextBox1.Text + "#, \"dd/mm/yyyy\") And format(#" + TextBox2.Text + "#, \"dd/mm/yyyy\")) AND Location = 2";
            }
            else
            {
                 query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where FecPed Between format(#" + TextBox1.Text + "#, \"dd/mm/yyyy\") And format(#" + TextBox2.Text + "#, \"dd/mm/yyyy\")";
            }
            //string query = "Select NumPed AS OC, FecPed AS Order_Date, CliPed AS Customer_Code, PedPed AS Cust_PO, Location FROM [Pedidos de clientes] Where OcDate is Null";
            OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
            DataTable dtCarbideInquiry = new DataTable();
            ad.Fill(dtCarbideInquiry);
        }
    }
}