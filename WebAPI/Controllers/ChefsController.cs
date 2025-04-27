using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly APIContext _context;

        public ChefsController(APIContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ChefAdd(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Chef Added Succesfully!");
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var value = _context.Chefs.ToList();
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult ChefDelete(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Chef Deleted Succesfully!");
        }

        [HttpGet("GetChef/ById")]
        public IActionResult GetChef(int id)
        {
            return Ok(_context.Chefs.Find(id));
        }

        [HttpPut]
        public IActionResult ChefUpdate(Chef Chef)
        {
            _context.Chefs.Update(Chef);
            _context.SaveChanges();
            return Ok("Chef Updated Succesfully!");
        }
    }
}
