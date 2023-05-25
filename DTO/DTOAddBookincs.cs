namespace Booking_System.DTO
{
    public class DTOAddBookincs
    {
      
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }
        public int Gust_id { get; set; }
        public ICollection<DTORoomusingBookin> Room { get; set; }
        =new List<DTORoomusingBookin>();


    }
}
