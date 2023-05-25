namespace Booking_System.DTO
{
    public class DTO_Room
    {

        public int Number_Ro { get; set; }  
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public IFormFile image_path { get; set; } 
        
        public string Room_Des { get; set; }  
        public int Avalable { get; set; }





    }
}
