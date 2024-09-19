namespace SurfsUp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string SelectedSurfboard { get; set; }

        public DateTime RentPeriod { get; set; }
        public TimeOnly RentHours { get; set; }
        public DateTime RentReturn { get; set; }

        public int SurfboardAmount { get; set; }
        public int Price { get; set; }
        public string Remarks { get; set; }

        public Booking(int bookingId, string customerName, string customerEmail, string customerPhone, string selectedSurfboard)
        {
            BookingId = bookingId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            SelectedSurfboard = selectedSurfboard;
            // NOTE We probably don't need to set RentPeriod & RentHours when making a new Booking, since the Customer selects, which is then validated, before ever being used ?
        }

        // Since we overwrote the default param-less constructor by making the one above,
        // we're manually remaking it here (so we can use it in RentOrderController easilier)
        public Booking ()
        {

        }
    }
}
