using Microsoft.AspNetCore.Mvc;
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
    public class StudentDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string RecordbookNumber { get; set; }
        public string GroupNum { get; set; }
    }
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public StudentsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("all")]
        public IEnumerable<Student> GetStudents() => _unitOfWork.Students.GetStudents();
        [HttpGet("group/{groupNumber}")]
        public IEnumerable<Student> GetStudentsByGroup(string groupNumber) => _unitOfWork.Students.GetStudentsByGroup(groupNumber);

        [HttpGet("{recordBookNumber}")]
        //public Student GetStudentByRecordBook(int recordBookNumber) => _unitOfWork.Students.GetStudentByRecordBook(recordBookNumber);
        public Student GetStudentByRecordBook(string recordBookNumber) => _unitOfWork.Students.GetStudentByRecordBook(recordBookNumber);

        // POST api/<StudentController>
        /*
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.Students.Add(student);
                _unitOfWork.SaveAsync().Wait();
            }
        }
        */
        [HttpPost]
        public void Post([FromBody] StudentDTO studentDTO)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var group = _unitOfWork.StudentsGroups.GetGroupByNumber(studentDTO.GroupNum);
                Student student = new Student
                {
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    MiddleName = studentDTO.MiddleName,
                    RecordbookNumber = studentDTO.RecordbookNumber,
                    Group = group,
                };
                _unitOfWork.Students.Add(student);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.Students.Update(value);
                _unitOfWork.SaveAsync().Wait();
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var student = _unitOfWork.Students.FindAsync(id);
                student.Wait();
                _unitOfWork.Students.Remove(student.Result);
                _unitOfWork.SaveAsync().Wait();
            }
        }
    }
}
