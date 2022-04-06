using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Interfaces.Models;

namespace DataService.Data.Repositories
{
    public class EmployeesRepository: RepositoryBase<Employee>
    {
        public EmployeesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }

        public Task<Employee> GetEmployeByUrlId(string urlId)
        {
            return GetFirstWhereAsync(employee => employee.UrlId == urlId);
        }
    }
}