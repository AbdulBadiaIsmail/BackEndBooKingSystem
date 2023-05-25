using Booking_System.DTO;

namespace Booking_System.Represent
{
    public interface Branch_context
    {
        List<DTO_Branch> GetAll();
        DTO_Branch GetByID(int id);
        void Add(DTO_Branch entity);
        void Update(int id, DTO_Branch entity);
        void Delete(int Entity);
    }

}
