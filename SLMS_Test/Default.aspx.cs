using System;
using System.Threading;
using System.Web.UI;
using SLMS.DataContext;
using SLMS.Entity;
using SLMS.Utilities;

namespace SLMS_Test
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayBooks();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hdnField.Value))
                {
                    Utilities.setPageMessage("Please select the book first.", Utilities.severity.error, Page.Master);
                    return;
                }

                Response.Redirect("CheckOut.aspx?bookID=" + int.Parse(hdnField.Value));
            }
            catch (ThreadAbortException ex)
            {
            }
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hdnField.Value))
            {
                Utilities.setPageMessage("Please select the book first.", Utilities.severity.error, Page.Master);
                return;
            }

            Response.Redirect("CheckIn.aspx?bookID=" + int.Parse(hdnField.Value));
        }


        private void displayBooks()
        {
            var genericDatContext = new GenericDatContext();

            try
            {
                var books = genericDatContext.GetBookList();

                BooksList.DataSource = books;
                BooksList.DataBind();
            }
            catch (Exception ex)
            {
                Utilities.setPageMessage(ex.Message, Utilities.severity.error, Page.Master);
                var applicationErrorDataContext = new ApplicationErrorDataContext();
                var errorEntity = new ErrorEntity();
                errorEntity.ErrorDateTime = DateTime.Now;
                errorEntity.ErrorDescription = ex.StackTrace;
                errorEntity.ErrorMessage = ex.Message;
                errorEntity.UserID = 0;
                applicationErrorDataContext.InsertApplicationError(errorEntity);
            }
        }
    }
}