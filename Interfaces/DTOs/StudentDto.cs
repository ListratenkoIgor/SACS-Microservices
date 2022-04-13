using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTOs
{
    public class StudentDto : IDtoEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string RecordbookNumber { get; set; }

        public StudentsGroupDto Group { get; set; }

    }
}
