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
        public async Task<Student> GetStudentByRecordBook(int recordBookNumber)
        {
            return await GetFirstWhereAsync(student=>student.RecordbookNumber==recordBookNumber);
        }
        public async Task<IEnumerable<Student>> GetStudentsByGroup(string groupNumber)
        {
            return await GetAllByWhereAsync(student=>student.Group.Number== groupNumber);
        }
    }
}