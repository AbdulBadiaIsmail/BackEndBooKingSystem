using Booking_System.DTO;
using Booking_System.Models;

namespace Booking_System.Represent
{
    public interface Room_context
    {
        List<DTOGetRoom> GetAll();
        DTOGetRoom GetByID(int id);
        void Add(DTOAddRoom entity);
        void Update(int id ,DTO_Room entity);
        void Delete(int Entity);
       List<DTOGetRoom> getRoombyName(int name);    

        List<DTOGetRoom> getRoomAvailable();

    }
    
}
