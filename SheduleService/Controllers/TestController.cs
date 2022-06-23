using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SheduleModelsLib.Models;
using Interfaces.Models;
using SheduleModelsLib.Models.JsonModels;
using SheduleModelsLib.Helpers;
using SheduleService.Data;
using AutoMapper;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.DependencyInjection;
using SheduleService.Data.Models;

namespace SheduleService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : MyControllerBase
    {
        private string SendRequest(string URL) {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri(URL));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            return content.Result;
        }
        private Task<HttpResponseMessage> SendRequestAsync(string URL)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri(URL));
            return response;
        }
        public UpdateInfo GetUpdateInfo(string URL,int Id) {
            var datejson = SendRequest(URL + Id.ToString());
            var date = JsonConvert.DeserializeObject<DateTime>(datejson, new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            });
            //dd.mm.yyyy
            return null;
        } 
        public TestController(UnitOfWork unitOfWork, IMapper mapper, IServiceScopeFactory serviceScopeFactory) : base(unitOfWork, mapper, serviceScopeFactory) { }
        [HttpGet("CheckUpdate")]
        public void CheckUpdate()
        {
            var DataServiceUrl = "http://localhost:53588/";
            var BsuirApiUrl = "https://iis.bsuir.by/api/v1/";
            var EmployeesJson = SendRequest(DataServiceUrl + "Employees");
            var Employees = JsonConvert.DeserializeObject<List<Employee>>(EmployeesJson);
            var GroupsJson = SendRequest(DataServiceUrl + "StudentsGroups");
            var Groups = JsonConvert.DeserializeObject<List<StudentsGroup>>(GroupsJson);
            UpdateList list = new UpdateList();

            var Url = "employee?id=";
            Parallel.ForEach<Employee>(Employees, x => list.EmployeesToUpdate.Add(GetUpdateInfo(BsuirApiUrl + Url, x.Id)));
            Url = "student-group?id=";
            Parallel.ForEach<StudentsGroup>(Groups, x => list.EmployeesToUpdate.Add(GetUpdateInfo(BsuirApiUrl + Url, x.Id)));
        }
        [HttpGet("Shedule/StudentGroup/{group}")]
        public DownStreamShedule GetShedulesByGroup(string group) {
            HttpClient client = new HttpClient();
             var response = client.GetAsync(new Uri("https://iis.bsuir.by/api/v1/schedule?studentGroup="+group));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            var str = content.Result;

            DownStreamShedule shedule = JsonConvert.DeserializeObject<DownStreamShedule>(content.Result);
            return shedule;
        }
        [HttpGet("Shedule/Employee/{Uid}")]
        public DownStreamShedule GetShedulesByUId(string Uid)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://iis.bsuir.by/api/v1/employees/schedule/"+Uid));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            var str = content.Result;
            DownStreamShedule shedule = JsonConvert.DeserializeObject<DownStreamShedule>(str);
            return shedule;
        }
        [HttpGet("StudentGroup/all")]
        public List<JsonStudentsGroup> GetAllGroups()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://iis.bsuir.by/api/v1/student-groups"));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            var str = content.Result;
            List<JsonStudentsGroup> groups = JsonConvert.DeserializeObject<List<JsonStudentsGroup>>(str);
            return groups;
        }
        [HttpGet("Employee/all")]
        public List<Employee> GetAllEmployees(string Uid)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://iis.bsuir.by/api/v1/employees/all"));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            var str = content.Result;
            List<JsonEmployee> employees = JsonConvert.DeserializeObject<List<JsonEmployee>>(str);
            try
            {
                return _mapper.Map<List<JsonEmployee>, List<Employee>>(employees);
            }
            catch {
                var x = new List<Employee>();
                foreach (var y in employees) x.Add(_mapper.Map<JsonEmployee, Employee>(y));
                return x;
            }
            //return employees;
        }
        private string GetLastUpdateDate(string url) {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://iis.bsuir.by/api/v1/last-update-date/" + url));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            var str = content.Result;
            return JsonConvert.DeserializeObject<string>(str);
        }

        [HttpGet("StudentGroup/{id}")]
        public string GetLastUpdateDateByGroupId(string id) => GetLastUpdateDate("student-group?id="+id);
        [HttpGet("StudentGroup/{groupNumber}")]
        public string GetLastUpdateDateByGroupName(string groupNumber) => GetLastUpdateDate("student-group?groupNumber="+groupNumber);
        [HttpGet("Employee/{id}")]
        public string GetLastUpdateDateByEmployeeId(string id) => GetLastUpdateDate("employee?id="+id);
        [HttpGet("Employee/{urlId}")]
        public string GetLastUpdateDateByEmployeeUrlId(string urlId) => GetLastUpdateDate("employee?url-id="+urlId);

        [HttpGet("{Uid}")]
        public DownStreamShedule GetEmpByUId(string Uid)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://iis.bsuir.by/api/v1/employees/schedule/" + Uid));
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();
            var str = content.Result;
            DownStreamShedule shedule = JsonConvert.DeserializeObject<DownStreamShedule>(str);
            return shedule;
        }
    }
}
