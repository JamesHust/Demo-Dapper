using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.DemoDapper.IServices;
using MISA.DemoDapper.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.Gets();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{studentId}")]
        public Student Get(string studentId)
        {
            return _studentService.Get(studentId);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            if (ModelState.IsValid) return _studentService.Insert(student);
            return null;
        }

        // PUT api/<StudentsController>/5
        [HttpPut]
        public Student Put([FromBody] Student student)
        {
            return _studentService.Update(student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{studentId}")]
        public Student Delete(string studentId)
        {
            return _studentService.Delete(studentId);
        }
    }
}
