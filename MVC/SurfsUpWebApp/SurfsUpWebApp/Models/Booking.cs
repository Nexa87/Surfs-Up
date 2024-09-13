namespace SurfsUpWebApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string? CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string SelectedSurfboard { get; set; }
        public int RentPeriod { get; set; }
        public int RentHours { get; set; }
        public Booking(int bookingId, string customerName, string customerEmail, string customerPhone, string selectedSurfboard, int rentPeriod, int rentHours)
        {
            BookingId = bookingId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            SelectedSurfboard = selectedSurfboard;
            RentPeriod = rentPeriod;
            RentHours = rentHours;
        }
        public Booking (string selectedSurfboard)
        {
            SelectedSurfboard = selectedSurfboard;
        }
       
        public Booking ()
        {

        }

    }
}
