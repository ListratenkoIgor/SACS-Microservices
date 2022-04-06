using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Models;
using DataService.Data;
namespace DataService.Implementations
{
    //TODO: Replace Student.RecordBookNumber int->string and commit migration
    public class DataServiceImpl : IDataService
    {
        private UnitOfWork _unitOfWork;

        public DataServiceImpl(UnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public Task<Employee> GetEmployee(string urlId)
        {
            return _unitOfWork.Employees.GetEmployeByUrlId(urlId);
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            return _unitOfWork.Employees.GetAllAsync();
        }

        public Task<IEnumerable<Faculty>> GetFaculties()
        {
            return _unitOfWork.Faculties.GetAllAsync();
        }

        public Task<Faculty> GetFaculty(int id)
        {
            return _unitOfWork.Faculties.FindAsync(id);
        }

        public Task<StudentsGroup> GetGroup(string groupNumber)
        {
            return _unitOfWork.StudentsGroups.GetGroupByNumber(groupNumber);
        }

        public Task<IEnumerable<StudentsGroup>> GetGroups()
        {
            return _unitOfWork.StudentsGroups.GetAllAsync();
        }

        public Task<IEnumerable<Speciality>> GetSpecialities()
        {
            return _unitOfWork.Specialities.GetAllAsync();
        }

        public Task<Speciality> GetSpeciality(int id)
        {
            return _unitOfWork.Specialities.FindAsync(id);
        }

        public Task<Student> GetStudentByRecordBook(int recordBookNumber)
        {
            return _unitOfWork.Students.GetStudentByRecordBook(recordBookNumber);
        }

        public Task<IEnumerable<Student>> GetStudentsByGroup(string groupNumber)
        {
            return _unitOfWork.Students.GetStudentsByGroup(groupNumber);
        }
    }
}
