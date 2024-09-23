namespace SurfsUpv3.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string? CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string SelectedSurfboard { get; set; }
        public DateTime RentPeriod {  get; set; } //Perioden man lejer i, indeholder den valgte dato
        public TimeOnly RentHours { get; set; } //lejetiden
        public DateTime RentReturn { get; set; } //Hvornår den afleveres. RentPeriod + RentHours
        public string Remarks { get; set; } //kommentar
        public int Price  { get; set; } //Lejeprisen (Købspris fra repo bruges)
        public string SelectedPrice {  get; set; }
        public int SurfboardAmount { get; set; }
        public Booking(int bookingId, string customerName, string customerEmail, string customerPhone, string selectedSurfboard, DateTime rentPeriod, TimeOnly rentHours, DateTime rentReturn, string remarks, int price, string selectedPrice, int surfboardAmount )
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
            SelectedPrice = selectedPrice;  
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
