namespace Booking_System.DTO
{
    public class DTOAddRoom
    {
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public IFormFile image_path { get; set; }
   
        public string Room_Des { get; set; }
        public string image_Name { get; set; }
        public int B_id { get; set; }
    }
}
