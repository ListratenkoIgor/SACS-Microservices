using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.DTOs
{
    public class FacultyDto : IDtoEntity
    {
        public int Id { get; set; }

        public string Abbrev { get; set; }
      
        public string Name { get; set; }
    }
}
