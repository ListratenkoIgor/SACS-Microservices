using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.Models
{
    public class StudentsGroup:IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        public string Number { get; set; }
        
        [Required]
        public virtual Speciality Speciality { get; set; }
    }
}
