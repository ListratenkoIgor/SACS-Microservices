using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
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
        
        public Employee GetEmployeeByUrlId(string urlId)
        {
            return _unitOfWork.Employees.GetEmployeByUrlId(urlId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.Employees.GetEmployees();
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return _unitOfWork.Faculties.GetFaculties();
        }

        public Faculty GetFacultyById(int id)
        {
            return _unitOfWork.Faculties.GetFacultyById(id);
        }
        
        public StudentsGroup GetGroupByNumber(string groupNumber)
        {
            return _unitOfWork.StudentsGroups.GetGroupByNumber(groupNumber);
        }

        public IEnumerable<StudentsGroup> GetGroups()
        {
            return _unitOfWork.StudentsGroups.GetGroups();
        }

        public IEnumerable<Speciality> GetSpecialities()
        {
            return _unitOfWork.Specialities.GetSpecialities();
        }

        public Speciality GetSpecialityById(int id)
        {
            return _unitOfWork.Specialities.GetSpecialityById(id);
        }

        public Student GetStudentByRecordBook(int recordBookNumber)
        {
            return _unitOfWork.Students.GetStudentByRecordBook(recordBookNumber);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _unitOfWork.Students.GetStudents();
        }

        public IEnumerable<Student> GetStudentsByGroup(string groupNumber)
        {
            return _unitOfWork.Students.GetStudentsByGroup(groupNumber);
        }
    }
}
