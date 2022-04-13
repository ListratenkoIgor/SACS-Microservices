using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SheduleModelsLib.Models;
using Interfaces.Models;

namespace SheduleService.Data.Repositories
{
    public class StudentsRepository: RepositoryBase<Student>
    {
        public StudentsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }
        public Student GetStudentByRecordBook(string recordBookNumber)
        {
            var query =
               from stud in ApplicationDbContext.Students
               where stud.RecordbookNumber == recordBookNumber
               select stud;
            return query.FirstOrDefault();
        }
        public IEnumerable<Student> GetStudents()
        {
            var query =
               from stud in ApplicationDbContext.Students
               select stud;
            return query;
        }
    }
}