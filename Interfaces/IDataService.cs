using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shed.CoreKit.WebApi;
using Interfaces.Models;

namespace Interfaces
{
    public interface IDataService
    {
        
        #region Faculty
        [Route("faculties/")]
        public IEnumerable<Faculty> GetFaculties();
        
        [Route("faculties/{id}")]
        public Faculty GetFaculty(int id);
        #endregion

        #region Employee
        [Route("employees/all/")]
        public IEnumerable<Employee> GetEmployees();
        
        [Route("employees/{urlId}")]
        public Employee GetEmployee(string urlId);
        #endregion
        
        #region Speciality
        [Route("specialities/")]
        public IEnumerable<Speciality> GetSpecialities();
        
        [Route("specialities/{id}")]
        public Speciality GetSpeciality(int id);
        #endregion

        #region StudentGroup

        [Route("groups/")]
        public IEnumerable<StudentsGroup> GetGroups();
        
        [Route("groups/{groupNumber}")]
        public StudentsGroup GetGroup(string groupNumber);
        #endregion

        #region Student
        [Route("students/group/{groupNumber}")]
        public IEnumerable<Student> GetStudentsByGroup(string groupNumber);
        /*
        [Route("students/{RecordbookNumber}")]
        public Task<Student> GetStudentByRecordBook(string RecordbookNumber);
        */
        [Route("students/{RecordbookNumber}")]
        public Student GetStudentByRecordBook(int recordBookNumber);
        #endregion


    }
}
