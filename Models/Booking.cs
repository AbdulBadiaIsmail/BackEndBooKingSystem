using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public DateTime Data_start { get; set; }    

        public DateTime? Date_End { get; set; }
        
        [ForeignKey("Guest")]
        public int Guet_id { get; set; }
        public double? Totalprice { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual List<Room> Rooms { get; set; }    

         
      
    }
}
