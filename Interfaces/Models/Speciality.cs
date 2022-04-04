using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.Models
{
    public class Speciality : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Abbrev { get; set; }
        
        [Required]
        public string Name { get; set; }
       
        [Required]
        public virtual Faculty Faculty { get; set; }
        
        [Required]
        public virtual EducationForm EducationForm { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }
    }
}
