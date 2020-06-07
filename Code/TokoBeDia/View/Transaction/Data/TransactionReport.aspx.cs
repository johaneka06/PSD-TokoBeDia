using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.Transaction.Data
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!TransactionReportController.isUserPermittedToAccess())
            {
                userWarnLbl.Text = "You're not authorized to access this page. Please login as admin!";
                logoutBtn.Visible = false;
            }
            else
            {
                TransactionReporting newReport = new TransactionReporting();
                ReportViewer.ReportSource = newReport;
                newReport.SetDataSource(GenerateData(TransactionReportController.getTransactionData()));
            }
        }

        private ReportDataset GenerateData(List<HeaderTransaction> listTransaction)
        {
            ReportDataset newDataset = new ReportDataset();
            var HeaderTransaction = newDataset.HeaderTransaction;
            var DetailTransaction = newDataset.DetailTransaction;

            for(int i = 0; i < listTransaction.Count; i++)
            {
                var ht = listTransaction.ElementAt(i);
                int grandTotal = 0;
                for (int j = 0; j < TransactionReportController.getDetailTransaction(ht.TransactionID).Count; j++)
                {
                    var dt = TransactionReportController.getDetailTransaction(ht.TransactionID).ElementAt(j);
                    int subTotal = (dt.Quantity * dt.Product.ProductPrice);
                    var DetailTransactionRow = DetailTransaction.NewRow();
                    DetailTransactionRow["TransactionID"] = dt.TransactionID;
                    DetailTransactionRow["ProductName"] = dt.Product.ProductName;
                    DetailTransactionRow["Qty"] = dt.Quantity;
                    DetailTransactionRow["Price"] = dt.Product.ProductPrice;
                    DetailTransactionRow["Subtotal"] = subTotal;
                    DetailTransaction.Rows.Add(DetailTransactionRow);
                    grandTotal += subTotal;
                }
                var HeaderTransactionRow = HeaderTransaction.NewRow();
                HeaderTransactionRow["TransactionID"] = ht.TransactionID;
                HeaderTransactionRow["UserName"] = ht.User.UName;
                HeaderTransactionRow["TransactionDate"] = ht.TransactionDate;
                HeaderTransactionRow["GrandTotal"] = grandTotal;
                HeaderTransaction.Rows.Add(HeaderTransactionRow);
            }

            return newDataset;
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie currentUser = HttpContext.Current.Request.Cookies["user_email"];
            HttpContext.Current.Response.Cookies.Remove("user_email");
            currentUser.Expires = DateTime.Now.AddDays(-7.0);
            currentUser.Value = null;
            HttpContext.Current.Response.Cookies.Set(currentUser);
            Session.Abandon();
            Response.Redirect("~/View/Home.aspx");
        }
    }
}