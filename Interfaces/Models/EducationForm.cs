using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.Models
{
    public class EducationForm : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
