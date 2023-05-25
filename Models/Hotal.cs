using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Booking_System.Models
{
    public class Hotal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
       public virtual List<Branch> Branches { get; set; }   
    }
}
