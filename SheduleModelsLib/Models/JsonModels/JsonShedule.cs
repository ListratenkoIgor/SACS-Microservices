using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SheduleModelsLib.Enums;
using Interfaces.Models;

namespace SheduleModelsLib.Models.JsonModels
{
    public class DownStreamShedule: StudentShedule
    {
    }
    public class DayShedule {
        [JsonProperty("weekDay")]
        public string WeekDay { get; set; }
        [JsonProperty("schedule")]
        public virtual List<Pair> Pairs { get; set; }
    }
    public class Pair : IEntity
    {        
        [JsonProperty("weekNumber")]
        public List<int> WeekNumber { get; set; }
        
        [JsonProperty("studentGroup")]
        public List<string> StudentsGroup { get; set; }
        
        [JsonProperty("studentGroupInformation")]
        public List<string> StudentsGroupInformation { get; set; }
        
        [JsonProperty("numSubgroup")]
        public int NumSubGroup { get; set; }
        
        [JsonProperty("auditory")]
        public List<string> Auditory { get; set; }
        
        [JsonProperty("lessonTime")]
        public string LessonTime { get; set; }
        
        [JsonProperty("startLessonTime")]
        public string StartLessonTime { get; set; }
        
        [JsonProperty("endLessonTime")]
        public string EndLessonTime { get; set; }
        
        [JsonProperty("gradebookLesson")]
        public object GradeBookLesson { get; set; }
        
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("subjectFullName")]
        public string SubjectFullName { get; set; }
        
        [JsonProperty("note")]
        public string Note { get; set; }
        
        [JsonProperty("lessonType")]
        public string LessonType { get; set; }
        
        [JsonProperty("employee")]
        public virtual List<JsonEmployee> Employee { get; set; }
        
        [JsonProperty("studentGroupModelList")]
        public object StudentGroupModelList { get; set; }
        
        [JsonProperty("gradebookLessonlist")]
        public object GradeBookLessonList { get; set; }
        
        [JsonProperty("zaoch")]
        public bool Zaoch { get; set; }
    }
    public class StudentShedule
    {
        [JsonProperty("employee")]
        public virtual JsonEmployee Employee { get; set; }
        
        [JsonProperty("studentGroup")]
        public virtual JsonStudentsGroup StudentGroup { get; set; }
        
        [JsonProperty("schedules")]
        public virtual List<DayShedule> Shedules { get; set; }
        
        [JsonProperty("examSchedules")]
        public virtual List<DayShedule> ExamShedules { get; set; }
        
        [JsonProperty("todayDate")]
        public string TodayDate { get; set; }
        
        [JsonProperty("todaySchedules")]
        public virtual List<DayShedule> TodayShedules { get; set; }
       
        [JsonProperty("tomorrowDate")]
        public string TomorrowDate { get; set; }
       
        [JsonProperty("tomorrowSchedules")]
        public virtual List<DayShedule> TommorowShedules { get; set; }
      
        [JsonProperty("currentWeekNumber")]
        public int? CurrentWeekNumber { get; set; }
       
        [JsonProperty("dateStart")]
        public string DateStart { get; set; }

        [JsonProperty("dateEnd")]
        public string DateEnd { get; set; }

        [JsonProperty("sessionStart")]
        public string SessionStart { get; set; }
        
        [JsonProperty("sessionEnd")]
        public string SessionEnd { get; set; }
        /*
         {
  "employee": null,
  "studentGroup": [StudentGroup],
  "schedules": [Schedule],
  "examSchedules": [Schedule],
  "todayDate": "09.03.2022",
  "todaySchedules": [ScheduleModel],
  "tomorrowDate": "10.03.2022",
  "tomorrowSchedules": [ScheduleModel],
  "currentWeekNumber": 4,
  "dateStart": "26.01.2022",
  "dateEnd": "14.03.2022",
  "sessionStart": null,
  "sessionEnd": null
}
         */
    }
}
