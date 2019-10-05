using System.Collections.Generic;
using System.Linq;
using SLMS.Entity;
using SLMS.Infrastructure;

namespace SLMS.DataContext
{
    public class GenericDatContext : System.Data.Linq.DataContext
    {
        public GenericDatContext() : base(ApplicationConfiguration.ConnectionString)
        {
            CommandTimeout = 7200;
        }

        public List<Book> GetBookList()
        {
            var query = "SELECT * FROM BOOK";
            return ExecuteQuery<Book>(query).ToList();
        }

        public List<CheckOutSummery> GetCheckOutSummeryForAllBooks()
        {
            var query =
                "SELECT * FROM CheckOutSummery COS INNER JOIN [dbo].[User] U ON COS.[User] = U.Id INNER JOIN Book B ON COS.Book = B.Id";
            return ExecuteQuery<CheckOutSummery>(query).ToList();
        }

        public List<CheckOutSummery> GetCheckOutSummeryByUser(int userId)
        {
            var query =
                "SELECT * FROM CheckOutSummery COS INNER JOIN [dbo].[User] U ON COS.[User] = U.Id INNER JOIN Book B ON COS.Book = B.Id WHERE U.Id = {0}";
            return ExecuteQuery<CheckOutSummery>(string.Format(query, userId)).ToList();
        }

        public List<CheckOutSummery> GetCheckOutSummeryByBook(int bookId)
        {
            var query =
                "SELECT * FROM CheckOutSummery COS INNER JOIN [dbo].[User] U ON COS.[User] = U.Id INNER JOIN Book B ON COS.Book = B.Id WHERE B.Id = {0}";
            return ExecuteQuery<CheckOutSummery>(string.Format(query, bookId)).ToList();
        }

        public int GetUserIdByMobileNumber(string MobileNumber)
        {
            var query = "SELECT Id FROM  [dbo].[User] U  [MobileNumber] = {0}";
            return ExecuteQuery<int>(string.Format(query, MobileNumber)).ToList().FirstOrDefault();
        }
    }
}