namespace Booking_System.DTO
{
    public class DTOUpdateBooking
    {
        public int Id { get; set; }
        public DateTime Datestart { get; set; } 
        public DateTime DateEnd { get; set; }   

        public int Gust_id { get; set; }
        public List<DTORoomusingBookin> Room_id { get; set; }   

         
    }
}
