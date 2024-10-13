namespace SurfsUpWebAPI.Models
{
    public class SiteLog
    {
        // Class which is premise for table in DB for logging 404-page-visits & API requests count

        public int Id { get; set; }
        public string? LogType { get; set; } // Whether it's a 404 or API call
        public DateTime Timestamp { get; set; }

        public SiteLog (string? logType)
        {
            LogType = logType;
            Timestamp = DateTime.Now;
        }

    }
}
