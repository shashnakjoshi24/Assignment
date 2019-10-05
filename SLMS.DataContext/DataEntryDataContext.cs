using System;
using SLMS.Entity;

namespace SLMS.DataContext
{
    public class DataEntryDataContext : GenericDatContext
    {
        public void InsertBookInformation(Book bookEntity)
        {
            var insertBookStmt = @"INSERT INTO [dbo].[Book]([BookTitle],[ISBN],[PublishingYear],[Price],[IsAvailable])
                               VALUES ('{0}','{1}','{2}',{3},{4})";
            ExecuteCommand(string.Format(insertBookStmt,
                bookEntity.BookTitle,
                bookEntity.ISBN,
                bookEntity.PublishingYear,
                bookEntity.Price,
                bookEntity.IsAvailable = true));
        }

        public void InsertUserInformation(User userEntity)
        {
            var insertUserStmt =
                @"INSERT INTO [dbo].[User]([FirstName],[LastName],[EmailId],[MobileNumber],[NationalId])
                               VALUES ('{0}','{1}','{2}',{3},{4})";
            ExecuteCommand(string.Format(insertUserStmt,
                userEntity.FirstName,
                userEntity.LastName,
                userEntity.EmailId,
                userEntity.MobileNumber,
                userEntity.NationalId));
        }

        public int InsertBorrowingInformation(CheckOutSummery checkOutSummeryEntity)
        {
            var insertUserStmt =
                @"INSERT INTO [dbo].[CheckOutSummery]([User],[Book],[CheckInDate],[CheckOutDate],[IsOverDue],[NumberOfDays])
                               VALUES ('{0}','{1}','{2}',{3},{4})";
            return ExecuteCommand(string.Format(insertUserStmt,
                checkOutSummeryEntity.User.Id,
                checkOutSummeryEntity.Book.Id,
                checkOutSummeryEntity.CheckInDate,
                checkOutSummeryEntity.CheckOutDate,
                checkOutSummeryEntity.IsOverDue = false,
                checkOutSummeryEntity.NumberOfDays));
        }

        public int UpdateSummery(int bookId)
        {
            var UpdateStmt = "Update dbo.CheckOutSummery Set CheckInDate = {0} Where BookId = {1}";
            return ExecuteCommand(string.Format(UpdateStmt, DateTime.Today, bookId));
        }

        public void UpdateBook(int bookId, bool IsCheckOut)
        {
            var UpdateStmt = "Update dbo.Book Set IsAvailable = {0} Where BookId = {1}";
            ExecuteCommand(string.Format(UpdateStmt, IsCheckOut, bookId));
        }
    }
}