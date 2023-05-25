using Booking_System.DTO;
using Booking_System.Represent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GustController : ControllerBase
    {
        Gust_Conext Conext;
        public GustController(Gust_Conext _Conext)
        {
            this.Conext = _Conext;  
        }
        [HttpPost]
        public ActionResult Post(DTOGust gust)
        {
            if (gust != null)
            {
                if (ModelState.IsValid)
                {
                    Conext.Add(gust);
                    return Ok();
                }
            }
            return BadRequest();    
        }

        [HttpGet]
        public ActionResult<List<getgust>> getAll()
        {
            return Conext.getAll();
        }
    }
}
