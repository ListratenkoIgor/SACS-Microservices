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
       
        public FacultyDto Faculty { get; set; }
        
        public EducationFormDto EducationForm { get; set; }

        public string Code { get; set; }
    }
}
