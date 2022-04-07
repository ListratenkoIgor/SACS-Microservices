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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDataService _dataService;
        public DepartmentsController(IDataService service)
        {
            _dataService = service;
        }
        //[HttpGet]
        //public IEnumerable<Department> GetGroups() => _dataService.GetGroups();

        //[HttpGet("{abbrev}")]
        //public Department GetDepartmentByAbbrev(string abbrev) => _dataService.GetDepartmentByAbbrev(abbrev);


        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
