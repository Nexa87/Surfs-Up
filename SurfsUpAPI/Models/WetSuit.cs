using System.ComponentModel.DataAnnotations;

namespace SurfsUpv3.Models
{
    public class WetSuit
    {
        public int WetSuitId { get; set; }
        [Required]
        public WetSuitGender wetSuitGender { get; set; }
        public enum WetSuitGender
        {
            Male, Female, Chid
        }
        [Required]
        public WetSuitSize wetSuitSize { get; set; }
        public enum WetSuitSize
        {
            Small, Medium, Large, XL, XXL
        }
        
        [Required]
        public int Stock { get; set; }

        // Antal bestilte våddragter
        [Range(0, int.MaxValue, ErrorMessage = "Antallet af våddragter skal være mindst 0")]
        public int QuantityOrdered { get; set; }
        public WetSuit (int wetSuitId, WetSuitGender gender, WetSuitSize size, int stock)
        {
            WetSuitId = wetSuitId;
            wetSuitGender = gender;
            wetSuitSize= size;
            Stock = stock;
            QuantityOrdered = 0;// Initierer bestilt antal til 0
        }

        public WetSuit()
        {

        }
    }
}
