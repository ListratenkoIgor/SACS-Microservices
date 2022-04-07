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
    public class SpecialityController : ControllerBase
    {
        private readonly IDataService _dataService;
        public SpecialityController(IDataService service)
        {
            _dataService = service;
        }
        [HttpGet]
        public IEnumerable<Speciality> GetSpecialities() => _dataService.GetSpecialities();

        [HttpGet("{id}")]
        public Speciality GetSpecialityById(int id) => _dataService.GetSpecialityById(id);

        // POST api/<SpecialityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpecialityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecialityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
