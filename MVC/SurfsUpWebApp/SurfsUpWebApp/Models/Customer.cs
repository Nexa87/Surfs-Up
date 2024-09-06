namespace SurfsUpWebApp.Models
{
    public class Customer
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        /* Mega fixed*/
        public Customer(string fullName,string email, string phone)
        {
            Fullname = fullName;
            Email = email;
            Phone = phone;
        }
    }
}
