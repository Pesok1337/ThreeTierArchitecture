using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientAsp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var xVal = TextBox1.Text;
            var yVal = TextBox2.Text;

            SrvcReference.Service1Client client = new SrvcReference.Service1Client("BasicHttpBinding_IService1");
            client.PostCustInfo(xVal, yVal);

            client.Close();
        }
        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            SrvcReference.Service1Client client = new SrvcReference.Service1Client("BasicHttpBinding_IService1");
            string customersInfo = client.GetCustomers();
            client.Close();
            string[] rows = customersInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string row in rows)
            {
                string[] cells = row.Split(';'); // Используем ';' для разделения
                TableRow tableRow = new TableRow();

                foreach (string cell in cells)
                {
                    TableCell tableCell = new TableCell();
                    tableCell.Text = cell.Trim();
                    tableRow.Cells.Add(tableCell);
                }

                DataTable.Rows.Add(tableRow);
            }
        }
    
        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            var xVal = TextBox1.Text;
            var yVal = TextBox2.Text;

            SrvcReference.Service1Client client = new SrvcReference.Service1Client("BasicHttpBinding_IService1");
            string Message = client.DeleteCustInfo(xVal, yVal);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Message+ "')", true);

            client.Close();
        }
    }
}