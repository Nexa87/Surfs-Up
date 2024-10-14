using System.ComponentModel.DataAnnotations;

namespace SurfsUpv3.Models
{
    public class WetSuit
    {
        public int WetSuitId { get; set; }
        
        public WetSuitGender Gender { get; set; }
        public enum WetSuitGender
        {
            [Display(Name = "Mand")]
            Male,
            [Display(Name = "Kvinde")]
            Female
        }
        
        public WetSuitSize Size { get; set; }
        public enum WetSuitSize
        {
            Small, Medium, Large, XL, XXL
        }

        public WetSuit (int wetSuitId, WetSuitGender gender, WetSuitSize size)
        {
            WetSuitId = wetSuitId;
            
        }

        public WetSuit()
        {

        }
    }
}
