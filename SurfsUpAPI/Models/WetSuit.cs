using System.ComponentModel.DataAnnotations;

namespace SurfsUpAPI.Models
{
    public class WetSuit
    {
        public int WetSuitId { get; set; }
        [Required]
        public WetSuitGender wetSuitGender { get; set; }
        public enum WetSuitGender
        {
            None, Male, Female, Child
        }
        [Required]
        public WetSuitSize wetSuitSize { get; set; }
        public enum WetSuitSize
        {
            Small, Medium, Large, XL, XXL
        }

        public WetSuit (int wetSuitId, WetSuitGender gender, WetSuitSize size)
        {
            WetSuitId = wetSuitId;
            size = size;
            gender = gender;
        }

        public WetSuit()
        {

        }
    }
}
