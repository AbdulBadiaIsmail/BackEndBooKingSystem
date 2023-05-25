using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Models
{
    public class Branch
    {
        [Key]
        public int B_Id { get; set; }   
        [Required]  
        public string B_Name { get; set; }
        [Required]
        public string B_Loaction { get; set; }
        [Required]
      
        public string B_Phone { get; set; }
        [ForeignKey("Hotal")]
        public int Hotal_code { get; set; }   
        public virtual Hotal Hotal { get; set; }
        public virtual ICollection<Room> Romms { get; set; }
     

    }
}
