using Booking_System.DTO;
using Booking_System.Models;

namespace Booking_System.Represent
{
    public interface BooKing_Contexts
    {

     
        int Update (int id, DTOUpdateBooking booking);

        List<SelectBooking> GetAll();
       IEnumerable<SelectBooking> GetBookingbyName(string name);
       void Delete(int id);

        int Add(DTOAddBookincs bookincs);

        getBookingById getBooKingById(int id);   


    }
}
