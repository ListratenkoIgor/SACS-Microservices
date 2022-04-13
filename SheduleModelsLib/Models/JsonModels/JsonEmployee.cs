using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Interfaces.Models;

namespace SheduleModelsLib.Models.JsonModels
{
    public class JsonEmployee : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Degree { get; set; }
        public string Rank { get; set; }
        public string PhotoLink { get; set; }
        public string CalendarId { get; set; }
        public virtual List<string> AcademicDepartment { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("urlId")]
        public string UrlId { get; set; }
        public string Fio { get; set; }
    }
}
