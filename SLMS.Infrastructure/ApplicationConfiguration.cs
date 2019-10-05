using System.Configuration;

namespace SLMS.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["BookCheckINOUTDBConnection"].ToString();

        public static int PenaltyCharge => int.Parse(ConfigurationManager.AppSettings["PenaltyCharges"]);
    }
}