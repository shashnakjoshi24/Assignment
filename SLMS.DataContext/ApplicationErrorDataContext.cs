using System;
using System.Collections.Generic;
using System.Linq;
using SLMS.Entity;

namespace SLMS.DataContext
{
    public class ApplicationErrorDataContext : GenericDatContext
    {
        public static ApplicationErrorDataContext Create()
        {
            return new ApplicationErrorDataContext();
        }

        public void InsertApplicationError(ErrorEntity errorEntity)
        {
            var insertErrorStmt =
                @"INSERT INTO [dbo].[Errors]([ErrorDateTime],[ErrorMessage],[ErrorDescription],[UserID])
                               VALUES ('{0}','{1}','{2}',{3})";
            ExecuteCommand(string.Format(insertErrorStmt,
                errorEntity.ErrorDateTime,
                errorEntity.ErrorMessage.Replace("'", ""),
                errorEntity.ErrorDescription.Replace("'", ""),
                errorEntity.UserID));
        }

        public List<ErrorEntity> GetErrorMessages(DateTime lastReportDate)
        {
            const string sql =
                @"SELECT ErrorDateTime, ErrorMessage, ErrorDescription, UserID FROM IL.Errors WHERE ErrorDateTime > '{0}'";
            return ExecuteQuery<ErrorEntity>(string.Format(sql, lastReportDate)).ToList();
        }
    }
}