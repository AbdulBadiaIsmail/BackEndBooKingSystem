using Booking_System.DTO;
using Booking_System.Models;
namespace Booking_System.Represent
{
    public class Gust_Serviescs : Gust_Conext
    {
        BookingContext contexts;


        public Gust_Serviescs(BookingContext contexts)
        {
            this.contexts = contexts;   
        }
        public void Add(DTOGust gust)
        {
             Guest g= new Guest();
            g.F_name = gust.F_Name;
            g.L_name = gust.L_Name;
            g.Email = gust.Emial;
      
            g.PhoneNumber = gust.phoneNumber;
            g.Counter = 0;
            contexts.Add(g);
            contexts.SaveChanges(); 
        }

        public List<getgust> getAll()
        {
            var gust = contexts.Guests.Select(x => new getgust
            {
                  id = x.Id,
                 F_Name  = x.F_name,
                 L_Name = x.L_name,
                 Emial = x.Email,
                 phoneNumber = x.PhoneNumber,
            }).ToList();
            return gust;
        }
    }
}
