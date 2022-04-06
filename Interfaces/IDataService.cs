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
        public Task<IEnumerable<Faculty>> GetFaculties();
        
        [Route("faculty/{id}")]
        public Task<Faculty> GetFaculty(int id);
        #endregion

        #region Speciality
        [Route("specialities/")]
        public Task<IEnumerable<Speciality>> GetSpecialities();
        
        [Route("speciality/{id}")]
        public Task<Speciality> GetSpeciality(int id);
        #endregion

        #region Employee
        [Route("employees/all/")]
        public Task<IEnumerable<Employee>> GetEmployees();
        
        [Route("employees/{urlId}")]
        public Task<Employee> GetEmployee(string urlId);
        #endregion

        #region StudentGroup

        [Route("groups/")]
        public Task<IEnumerable<StudentsGroup>> GetGroups();
        
        [Route("group/{groupNumber}")]
        public Task<StudentsGroup> GetGroup(string groupNumber);
        #endregion

        #region Student
        [Route("students/group/{groupNumber}")]
        public Task<IEnumerable<Student>> GetStudentsByGroup(string groupNumber);
        /*
        [Route("students/{RecordbookNumber}")]
        public Task<Student> GetStudentByRecordBook(string RecordbookNumber);
        */
        [Route("students/{RecordbookNumber}")]
        public Task<Student> GetStudentByRecordBook(int recordBookNumber);
        #endregion


    }
}
