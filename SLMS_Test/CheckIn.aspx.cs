using System;
using System.Linq;
using System.Web.UI;
using SLMS.DataContext;
using SLMS.Domain;
using SLMS.Utilities;

namespace SLMS_Test
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var selectedBookID = 0;
            if (!string.IsNullOrWhiteSpace(Request.QueryString["bookID"]))
                selectedBookID = int.Parse(Request.QueryString["bookID"]);
            // to do error message

            displayBorrowerDeails(selectedBookID);
        }

        private void displayBorrowerDeails(int BookID)
        {
            var dbOperations = new GenericDatContext();
            var borrower = dbOperations.GetCheckOutSummeryByBook(BookID).ToList().FirstOrDefault();

            if (borrower != null)
            {
                lblName.Text = borrower.User.FirstName + borrower.User.LastName;
                lblMobile.Text = borrower.User.MobileNumber;
                lblReqReturnDate.Text = borrower.CheckOutDate.AddDays(21).ToShortTimeString();
                lblReturnDate.Text = DateTime.Now.ToString();

                var NumberOfDaysPassed = borrower.CheckOutDate.GetNumberOfDays();
                var penaltyAmount = NumberOfDaysPassed.CalculatePenalty();
                lblPenaltyAmount.Text = string.Format("{0:#,##0.00}", penaltyAmount);
            }
            else
            {
                Utilities.setPageMessage("Book is either already checked in or was not found.",
                    Utilities.severity.error, Page.Master);
            }
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            var dbOperations = new DataEntryDataContext();

            var selectedBookID = 0;
            if (!string.IsNullOrWhiteSpace(Request.QueryString["bookID"]))
            {
                selectedBookID = int.Parse(Request.QueryString["bookID"]);
            }

            var result = dbOperations.UpdateSummery(selectedBookID);

            if (result == 0)
            {
                Utilities.setPageMessage("Encountered an error while checking in.", Utilities.severity.error,
                    Page.Master);
                return;
            }

            Utilities.setPageMessage("Book has been checked in successfully.", Utilities.severity.info, Page.Master);
        }
    }
}