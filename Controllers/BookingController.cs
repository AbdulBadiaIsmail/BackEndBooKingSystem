using Booking_System.DTO;
using Booking_System.Models;
using Booking_System.Represent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BooKing_Contexts _Contexts; 
        public BookingController(BooKing_Contexts contexts)
        {
            this._Contexts = contexts;  
        }
        [HttpPost]
        public ActionResult Add(DTOAddBookincs booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                   if(   _Contexts.Add(booking) ==1)
                {
                    return Created("", booking);
                } 
                else
                {
                    return BadRequest();
                }
                    
               
            }
            }
        [HttpPut("updata/{id}")]
        public ActionResult Update(int id, DTOUpdateBooking bookin)
        {
            if (id !=bookin.Id)
            {
                return BadRequest();
            }
            else
            {
               if(  _Contexts.Update(id, bookin)==1)
                return Ok(bookin);
                else
                    return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult<List<SelectBooking>> getAlL()
        {
            return Ok(_Contexts.GetAll());
        }
        [HttpGet("name")]
        public ActionResult<IEnumerable<SelectBooking>>getBookingByName([FromQuery]string Name)
        {
            if (Name!=null)
            {
                return Ok(_Contexts.GetBookingbyName(Name));    
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Remove(int id)
        {
            if (id<0)
            {
                return BadRequest();
            }
            else
            {
                _Contexts.Delete(id);
                return Ok();
            }
        }

        [HttpGet("getbyid/{id}")] 
        public ActionResult<getBookingById> getById (int id )
        {
            _Contexts.getBooKingById(id);
            return Ok( _Contexts.getBooKingById(id));
        }

    }
}
