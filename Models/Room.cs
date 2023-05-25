using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Models
{
    public class Room
    {
        [Key]
        public int Room_id { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public string  Image { get; set; }  
        public string Room_Dec { get; set; }    

        public string Room_type { get; set; }
        [ForeignKey("Branch")]
        public int B_id { get; set; }
        
        public int? Availability { get; set; }  
        public virtual List<Booking> Bookings { get; set; } 
        =new List<Booking>();
      
        public virtual Branch Branch { get; set; }  
         


         
    }
}
