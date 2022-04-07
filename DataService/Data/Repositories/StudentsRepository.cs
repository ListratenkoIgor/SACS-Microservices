using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Interfaces.Models;

namespace DataService.Data.Repositories
{
    public class StudentsRepository: RepositoryBase<Student>
    {
        public StudentsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }
        /*
        public async Task<Student> GetStudentByRecordBook(string recordBookNumber) {
            return await GetFirstWhereAsync(student=>student.RecordbookNumber==recordBookNumber);
        }
        */
        public Student GetStudentByRecordBook(int recordBookNumber)
        {
            var query =
               from stud in ApplicationDbContext.Students
               where stud.RecordbookNumber == recordBookNumber
               select stud;
            return query.FirstOrDefault();
        }
        public IEnumerable<Student> GetStudentsByGroup(string groupNumber)
        {
            var query =
               from stud in ApplicationDbContext.Students
               where stud.Group.Number == groupNumber
               select stud;
            return query;
        }
    }
}