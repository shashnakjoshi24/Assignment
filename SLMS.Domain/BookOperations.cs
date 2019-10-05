using System;
using SLMS.Infrastructure;

namespace SLMS.Domain
{
    public static class BookOperations
    {
        public static int GetNumberOfDays(this DateTime bookingDate)
        {
            var businessDays =
                1 + ((DateTime.Today - bookingDate).TotalDays * 5 -
                     (bookingDate.DayOfWeek - DateTime.Today.DayOfWeek) * 2) / 7;

            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday) businessDays--;
            if (bookingDate.DayOfWeek == DayOfWeek.Sunday) businessDays--;


            return int.Parse(Math.Round(businessDays).ToString());
        }


        public static double CalculatePenalty(this int NumberOfDays)
        {
            return NumberOfDays > 15 ? (NumberOfDays - 15) * ApplicationConfiguration.PenaltyCharge : 0;
        }

        public static bool ShouldNotification(int NumberofDays)
        {
            return NumberofDays > 15 ? true : false;
        }
    }
}