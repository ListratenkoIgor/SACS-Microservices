﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Interfaces;
using DataService.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public FacultyController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Faculty> GetFaculties() => _unitOfWork.Faculties.GetFaculties();

        [HttpGet("{id}")]
        public Faculty GetFacultyById(int id) => _unitOfWork.Faculties.GetFacultyById(id);

        [HttpPost]
        public void Post([FromBody] Faculty faculty)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.Faculties.Add(faculty);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Faculty faculty)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.Faculties.Update(faculty);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var qroup = _unitOfWork.Faculties.FindAsync(id);
                qroup.Wait();
                _unitOfWork.Faculties.Remove(qroup.Result);
                _unitOfWork.SaveAsync().Wait();
            }
        }
    }
}
