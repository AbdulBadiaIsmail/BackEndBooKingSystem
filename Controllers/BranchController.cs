using Booking_System.DTO;
using Booking_System.Represent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        Branch_context branch;
        public BranchController(Branch_context branch)
        {
            this.branch = branch;
        }
        [HttpGet]
        public ActionResult<List<DTO_Branch>> GetAll()
        {
            
            return Ok(branch.GetAll());
        }

        [HttpPost]  
        public ActionResult Add(DTO_Branch entity)
        {
            if (ModelState.IsValid)
            {
                branch.Add(entity);
                return Created("", entity);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult update(int id , DTO_Branch Entity)
        {
            if (id != Entity.B_id)
            {
                return NotFound();
            }
            else
            {
                branch.Update(id, Entity);
                return Ok();
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<DTO_Branch> getByid(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            else
            {
                
                return Ok(branch.GetByID(id));
            }
        }
        [HttpDelete]
        public ActionResult Delete (int id )
        {
            if (id <= 0)
            {
                return NotFound();
            }
            else
            {
                branch.Delete(id);
                return  Ok();
            }
        }

    }
}
