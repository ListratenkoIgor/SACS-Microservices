using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataService _dataService;
        public StudentsController(IDataService service)
        {
            _dataService = service;
        }
        [HttpGet("/all")]
        public IEnumerable<Student> GetStudents() => _dataService.GetStudents();
        [HttpGet("group/{groupNumber}")]
        public IEnumerable<Student> GetStudentsByGroup(string groupNumber) => _dataService.GetStudentsByGroup(groupNumber);

        [HttpGet("{recordBookNumber}")]
        public Student GetStudentByRecordBook(int recordBookNumber) => _dataService.GetStudentByRecordBook(recordBookNumber);
        //public Student GetStudentByRecordBook(string recordBookNumber) => _dataService.GetStudentByRecordBook(recordBookNumber);

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
