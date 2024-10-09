namespace SurfsUpWebAPI.Models
{
    public class SiteVisit
    {
        // Class for when a user visits a site
        // Basis for table in API database, which holds info about [the two PO-requirements, of week 40]:
        // - User contacting API
        // - User requesting a non-existant page (404)

        public string Id { get; set; }
        public string User { get; set; }
        public string TypeOfVisit { get; set; } // "404" or "API call"
    }
}
