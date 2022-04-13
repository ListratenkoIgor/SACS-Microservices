using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Interfaces.DTOs;
using Interfaces.Helpers;
using DataService.Data;
using AutoMapper;

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : MyControllerBase
    {
        public TestController(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        [HttpGet]
        public List<Speciality> GetFaculty1ById() {
            var collection = new List<Speciality>();
            var faculty = new Faculty
            {
                Id = 45678,
                Abbrev = "FKSiS",
                Name = "seti"
            };
            var form = new EducationForm
            {
                Id = 34567,
                Name = "Daily"
            };
            var speciality = new Speciality
            {
                Id = 1234,
                Abbrev = "poit",
                Name = "prog obes info tech",
                Code = "1-08 09",
                EducationForm = form,
                Faculty = faculty
            };
            var group = new StudentsGroup
            {
                Id = 11,
                Course = 4,
                Number = "08",
                Speciality = speciality
            };
            var student = new Student
            {
                Id = 1,
                FirstName = "11",
                LastName = "22",
                MiddleName = "33",
                RecordbookNumber = "80",
                Group = group
            };

            /*
            var faculty2 = _mapper.Map<FacultyDto>(faculty);
            collection.Add(faculty);
            //collection.Add(faculty2);
            faculty = _mapper.Map<Faculty>(faculty2);
            collection.Add(faculty);


            var speciality2 = _mapper.Map<SpecialityDto>(speciality);
            collection.Add(speciality);
            collection.Add(speciality2);
            //speciality = _mapper.Map<Speciality>(speciality2);
            //collection.Add(speciality);


            var group2 = _mapper.Map<StudentsGroupDto>(group);
            collection.Add(group);
            //group = _mapper.Map<StudentsGroup>(group2);
            //collection.Add(group);
            var student2 = _mapper.Map<StudentDto>(student);
            collection.Add(student);
            collection.Add(student2);
            */
            //student = _mapper.Map<Student>(student2);
            //collection.Add(student);
            var speciality2 = _mapper.Map<SpecialityDto>(speciality);
            //collection.Add(speciality);
            //collection.Add(speciality2);
            speciality = _mapper.Map<Speciality>(speciality2);
            collection.Add(speciality);
            return collection;
        }
        [HttpGet("group")]
        public List<StudentsGroup> GetFacultyBy1Id()
        {
            var collection = new List<StudentsGroup>();
            var faculty = new Faculty
            {
                Id = 45678,
                Abbrev = "FKSiS",
                Name = "seti"
            };
            var form = new EducationForm
            {
                Id = 34567,
                Name = "Daily"
            };
            var speciality = new Speciality
            {
                Id = 1234,
                Abbrev = "poit",
                Name = "prog obes info tech",
                Code = "1-08 09",
                EducationForm = form,
                Faculty = faculty
            };
            var group = new StudentsGroup
            {
                Id = 11,
                Course = 4,
                Number = "08",
                Speciality = speciality
            };
            var student = new Student
            {
                Id = 1,
                FirstName = "11",
                LastName = "22",
                MiddleName = "33",
                RecordbookNumber = "80",
                Group = group
            };

            collection.Add(group);

            return collection;
        }
        [HttpGet("studentdto")]
        public List<StudentDto> GetFacu1ltyBy1Id()
        {
            var collection = new List<StudentDto>();
            var faculty = new Faculty
            {
                Id = 45678,
                Abbrev = "FKSiS",
                Name = "seti"
            };
            var form = new EducationForm
            {
                Id = 34567,
                Name = "Daily"
            };
            var speciality = new Speciality
            {
                Id = 1234,
                Abbrev = "poit",
                Name = "prog obes info tech",
                Code = "1-08 09",
                EducationForm = form,
                Faculty = faculty
            };
            var group = new StudentsGroup
            {
                Id = 11,
                Course = 4,
                Number = "08",
                Speciality = speciality
            };
            var student = new Student
            {
                Id = 1,
                FirstName = "11",
                LastName = "22",
                MiddleName = "33",
                RecordbookNumber = "80",
                Group = group
            };

            var student2 = _mapper.Map<StudentDto>(student);
            collection.Add(student2);

            return collection;
        }
    }
}
