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
    public class StudentsGroupController : ControllerBase
    {
        private readonly IDataService _dataService;
        public StudentsGroupController(IDataService service) {
            _dataService = service;
        }
        [HttpGet]
        public IEnumerable<StudentsGroup> GetGroups() => _dataService.GetGroups();

        [HttpGet("{groupNumber}")]
        public StudentsGroup GetGroupByNumber(string groupNumber) => _dataService.GetGroupByNumber(groupNumber);

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
