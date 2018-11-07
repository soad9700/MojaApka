﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojaApka.Domains;
using MojaApka.Data;

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

        [HttpGet("students")]
        public IActionResult Get()
        {
            return Json(_context.Students.AsEnumerable());
        }

        [HttpPut("students/{id}")]
        public IActionResult Update(int id, [FromBody] CreateStudent createStudent)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            student.Name = createStudent.Name;
            _context.Update(student);
            _context.SaveChanges();
            return StatusCode(204);
        }

        [HttpDelete("students/{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return StatusCode(202);
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
