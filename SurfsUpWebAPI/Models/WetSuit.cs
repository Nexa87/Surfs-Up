using System.ComponentModel.DataAnnotations;

namespace SurfsUpWebAPI.Models
{
    public class WetSuit
    {
        [Key]
        public int WetsuitId { get; set; }
        public string Size { get; set; }
        public string Gender { get; set; }
        
        
        public enum WetSuitGender
        {
            Male, Female
        }
    
    
        public enum WetSuitSize
        {
            Small, Medium, Large, XL, XXL
        }

        public WetSuit (int wetSuitId)
        {
            WetsuitId = wetSuitId;
           
        }

        public WetSuit()
        {

        }
    }
}
