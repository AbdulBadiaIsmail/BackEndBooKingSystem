using Booking_System.Models;
using System.Diagnostics.CodeAnalysis;

namespace Booking_System.Represent.Equaloperator
{
    public class IEqual : IEqualityComparer<Room>
    {
        public bool Equals(Room x, Room y)
        {
            return x.Room_id ==y.Room_id;
        }

        public int GetHashCode([DisallowNull] Room obj)
        {
           return obj.Room_id.GetHashCode();
        }
    }
}
