using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Interfaces.DTOs;
using DataService.Data;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : MyControllerBase
    {
        public StudentsController(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
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
        public void Post([FromBody] StudentDto studentDTO)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                /*
                var group = _unitOfWork.StudentsGroups.GetGroupByNumber(studentDTO.Group);
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
                */
            }
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentDto value)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var stud = _unitOfWork.Students.GetFirstWhere(s => s.Id == value.Id);
                _unitOfWork.Students.Update(stud);
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
