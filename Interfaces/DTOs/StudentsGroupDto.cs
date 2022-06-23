using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.DTOs
{
    public class StudentsGroupDto : IDtoEntity
    {
        public int Id { get; set; }

        public int Course { get; set; }

        public string Number { get; set; }
        
        public int SpecialityId { get; set; }
    }
}
