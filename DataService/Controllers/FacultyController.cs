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
    public class FacultyController : ControllerBase
    {
        private readonly IDataService _dataService;
        public FacultyController(IDataService service)
        {
            _dataService = service;
        }
        [HttpGet]
        public IEnumerable<Faculty> GetFaculties() => _dataService.GetFaculties();

        [HttpGet("{id}")]
        public Faculty GetFacultyById(int id) => _dataService.GetFacultyById(id);

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FacultyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FacultyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
