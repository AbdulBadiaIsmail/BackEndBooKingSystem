using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string F_name { get; set; }
        [Required]
        public string L_name { get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Column(TypeName ="Char"),MaxLength(11),MinLength(11)]
        public string PhoneNumber { get; set; }

        public int Counter { get; set; }    
    
        public virtual  List<Booking> Booking { get; set; }    
    } 
}
