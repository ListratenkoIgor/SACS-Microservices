using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SheduleModelsLib.Models.JsonModels;
using Interfaces.Models;

namespace SheduleModelsLib.Helpers
{
    public class SheduleJsonMapperProfile : Profile
    {

        
        public SheduleJsonMapperProfile()
        {
            CreateMap<JsonEmployee, Employee>().ForMember(dest=>dest.AcademicDepartment,opt=>opt.MapFrom(src=>new List<Department>()));

            /*
                public string PhotoLink { get; set; }
                public string CalendarId { get; set; }
                public virtual List<string> AcademicDepartment { get; set; }
                public string Fio { get; set; }

                public virtual ICollection<Department> AcademicDepartment { get; set; }
             */
            /*
            CreateMap<Department,DepartmentDto>().ReverseMap();
            CreateMap<EducationForm,EducationFormDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.AcademicDepartment, opt => opt.MapFrom(src=> MapAcademicDepartmentToDto(src.AcademicDepartment)));
            CreateMap<Faculty,FacultyDto>().ReverseMap();
            CreateMap<Speciality, SpecialityDto>()
                .ForMember(dest => dest.EducationForm, opt => opt.MapFrom(src => src.EducationForm.Id))
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Faculty.Id));
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group.Number));
            CreateMap<StudentsGroup, StudentsGroupDto>()
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src=>src.Speciality.Name+"|"+src.Speciality.Code));

            CreateMap<EmployeeDto, Employee>();
            // .ForMember(dest => dest.AcademicDepartment, opt => opt.MapFrom(src=> new List<Department>()));
            CreateMap<SpecialityDto, Speciality>();
               // .ForMember(dest=>dest.EducationForm,opt => opt.MapFrom(src=> new EducationForm()))
               // .ForMember(dest=>dest.Faculty, opt => opt.MapFrom(src =>new Faculty()));
            CreateMap<StudentDto, Student>();
               //.ForMember(dest=>dest.Group, opt => opt.MapFrom(src => new StudentsGroup()));
            CreateMap<StudentsGroupDto, StudentsGroup>();
               // .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => new Speciality()));
            */
        }
    }
}
