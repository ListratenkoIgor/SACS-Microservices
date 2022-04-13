using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Interfaces.DTOs
{
    public class EmployeeDto : IDtoEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Degree { get; set; }

        public string Rank { get; set; }

        public string UrlId { get; set; }

        public ICollection<DepartmentDto> AcademicDepartment { get; set; }
    }
}
