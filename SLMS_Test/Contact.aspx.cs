using System;
using System.Web.UI;
using SLMS.DataContext;
using SLMS.Entity;
using SLMS.Utilities;

namespace SLMS_Test
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var selectedBookID = 0;
            if (!string.IsNullOrWhiteSpace(Request.QueryString["bookID"]))
            {
                selectedBookID = int.Parse(Request.QueryString["bookID"]);
            }
            // to do error message

            lblCheckOutDate.Text = DateTime.Now.ToString();
            lblReturnDate.Text = Utilities.getDateAfterSpecifiedBusinessDays(15).ToString();

            DisplayBookCheckOutHistory(selectedBookID);
        }

        private void DisplayBookCheckOutHistory(int bookId)
        {
            var dbOperations = new GenericDatContext();
            var borrowers = dbOperations.GetCheckOutSummeryByBook(bookId);

            HistoryList.DataSource = borrowers;
            HistoryList.DataBind();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            var selectedBookID = 0;
            if (!string.IsNullOrWhiteSpace(Request.QueryString["bookID"]))
            {
                selectedBookID = int.Parse(Request.QueryString["bookID"]);
            }
            else
            {
                Utilities.setPageMessage("Please select a book.", Utilities.severity.error, Page.Master);
                return;
            }

            var dbOperations = new DataEntryDataContext();

            var bookName = txtName.Text;
            var mobileNo = txtMobile.Text;
            var nationalID = txtNationalID.Text;
            var checkOutDate = DateTime.Parse(lblCheckOutDate.Text);

            var checkOutSummery = new CheckOutSummery();
            checkOutSummery.Book.Id = selectedBookID;
            checkOutSummery.User.Id = dbOperations.GetUserIdByMobileNumber(mobileNo);
            checkOutSummery.CheckOutDate = checkOutDate;
            var result = dbOperations.InsertBorrowingInformation(checkOutSummery);

            if (result == 0)
            {
                Utilities.setPageMessage("Encountered an error while checking out.", Utilities.severity.error,
                    Page.Master);

                return;
            }

            Utilities.setPageMessage("Book has been checked out in the name of " + txtName.Text,
                Utilities.severity.info, Page.Master);

            DisplayBookCheckOutHistory(selectedBookID);
        }
    }
}