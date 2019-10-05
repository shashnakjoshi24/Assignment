using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLMS.Utilities
{
    public static class Utilities
    {
        public enum severity
        {
            info,
            error
        }

        /// <summary>
        ///     This function calculates the date after specified number of work/business days
        ///     Friday and Saturday are treated as off days.
        /// </summary>
        /// <param name="days">Business days</param>
        /// <returns>Target Date</returns>
        public static DateTime getDateAfterSpecifiedBusinessDays(int days)
        {
            var TargetDate = DateTime.Now.AddDays(15);

            return TargetDate;
        }

        public static void setPageMessage(string message, severity level, MasterPage master)
        {
            var messageLabel = (Label) master.FindControl("lblMessage");
            messageLabel.Text = message;

            if (level == severity.error)
                messageLabel.ForeColor = Color.Red;
            else
                messageLabel.ForeColor = Color.Green;
        }
    }
}