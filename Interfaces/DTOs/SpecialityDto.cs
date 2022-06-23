using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.DTOs
{
    public class SpecialityDto : IDtoEntity
    {
        public int Id { get; set; }

        public string Abbrev { get; set; }
        
        public string Name { get; set; }
       
        public int FacultyId { get; set; }
        
        public int EducationFormId { get; set; }

        public string Code { get; set; }
    }
}
