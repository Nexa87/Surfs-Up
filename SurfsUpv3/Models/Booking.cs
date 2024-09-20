using System.ComponentModel.DataAnnotations;

namespace SurfsUpv3.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required (ErrorMessage = " * Du har glemmet din navn!")]
        public string? CustomerName { get; set; }
        [Required (ErrorMessage = " * Maa vi ikke kontakte dig med godeste tilbuder ? :(")]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength (8, MinimumLength = 8, ErrorMessage = "Telephöwne er paa 8 cifre homie, forever and always..")]

        // RegEx example ; Her because Nekolai siger RegEx ofte + som learning aid
        // What it does : Sikrer at input'et er 8 characters lang, supposedly (untested because, det ovenover her works fine)
        // [RegularExpression (@"^\d{8}$", ErrorMessage = "Telephöwne skal kun indeholde 8 cifre.")]

        public string CustomerPhone { get; set; }

        // Not needed, since the surfboard being picked is the first step before even getting to typing in all the other info for a booking
        // But keeping it here for future reference
        // [Required] 
        public string SelectedSurfboard { get; set; }
        public DateTime RentPeriod {  get; set; }
        public TimeOnly RentHours { get; set; }
        public DateTime RentReturn { get; set; }
        public string Remarks { get; set; }
        public int Price  { get; set; }
        
        public int SurfboardAmount { get; set; }
        public Booking(int bookingId, string customerName, string customerEmail, string customerPhone, string selectedSurfboard, DateTime rentPeriod, TimeOnly rentHours, DateTime rentReturn, string remarks, int price, int surfboardAmount)
        {
            BookingId = bookingId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            SelectedSurfboard = selectedSurfboard;
            RentPeriod = rentPeriod;
            RentHours = rentHours;
            RentReturn = rentReturn;
            Remarks = remarks;
            Price = price;
            SurfboardAmount = surfboardAmount;
        }
        public Booking(string selectedSurfboard)
        {
            SelectedSurfboard = selectedSurfboard;
        }
       
        public Booking()
        {

        }

    }
}
