namespace Booking_System.DTO
{
    public class getBookingById
    {
        public int id { get; set; }
        public DateTime DataStrat { get; set; }
        public DateTime DataEnd { get; set; }
        public int Gust_id { get; set; }
        public List<DTOGetRoom> Room { get; set; }
        



    }
}
