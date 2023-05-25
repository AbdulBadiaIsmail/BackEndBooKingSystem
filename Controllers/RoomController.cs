using Booking_System.DTO;
using Booking_System.Models;
using Booking_System.Represent;
using Booking_System.Represent.Equaloperator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking_System.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        Room_context _Context;
        public RoomController(Room_context room)
        {
            this._Context = room;
        }
        [HttpGet]   
        public ActionResult<List<DTOGetRoom>> getAll()
        {
           return _Context.GetAll(); ;
        }
        [HttpPost]
        public ActionResult AddRoom([FromForm]DTOAddRoom room)
        {
            
        //    room.image_Name = UploadFile.getPath(room.image_path);
            if (ModelState.IsValid)
            {
                _Context.Add(room); 
               return Ok();
            }
            else
            {
                return BadRequest();
            }

            
        }

        [HttpGet("{id}")]
        public ActionResult<DTOGetRoom> getRoombyid(int id )
        {
            if (id <=0)
            {
                return NotFound();
            }
            else
            {

                return _Context.GetByID(id);
            }
        }
        [HttpPost]
        [Route("updateRoom/{id}")]
        public ActionResult updataRoom (int id ,[FromForm] DTO_Room room)
        {
            if (id != room.Number_Ro)
            {
                return BadRequest();
            }
            else
            {
                _Context.Update(id, room);
                return Ok();   
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete (int id )
        {
            if(id <=0)
            {
                return BadRequest();
            }
            else
            {
                _Context.Delete(id);
                 return Ok();
            }
        }
        [HttpGet]
        [Route("getRoombyAve/{available}")]
        public ActionResult<List<DTOGetRoom>> getRoombyAve(int available)
        {
            if (available < 0 && available >1)
            {
                return NotFound();
            }
            else
            {
                return Ok(_Context.getRoombyName(available));   
            }
        }
        [HttpGet]
        [Route ("getRoomAvailable")]
        public ActionResult<List<DTOGetRoom>> getRoomAvailable()
        {
            return _Context.getRoomAvailable();
        }

    }
}
