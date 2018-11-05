using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojaApka.Domains;
using MojaApka.Nowy_folder;

namespace MojaApka.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly MojaApkaContext _context;

        public ValuesController(MojaApkaContext context)
        {
            _context = context;
        }

        [HttpGet("students/{id}")]
        public ActionResult<string> Get(int id)
        {
            return Json(_context.Students.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost ("students")]
        public IActionResult Post([FromBody] CreateStudent createStudent)
        {
            var student = new Student() {Name = createStudent.Name}; 
            _context.Students.Add(student);
            _context.SaveChanges();
            return StatusCode(201);
        }
    }
}
