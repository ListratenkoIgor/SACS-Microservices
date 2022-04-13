using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Interfaces.Models;

namespace SheduleModelsLib.Models.JsonModels
{
    public class JsonStudentsGroup : IEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int SpecialityDepartmentEducationFormId { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        public string CalendarId { get; set; }
    }
}
