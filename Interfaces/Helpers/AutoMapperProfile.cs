using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Models;
using Interfaces.DTOs;

namespace Interfaces.Helpers
{
    public class AutoMapperProfile : Profile
    {
        private string MapAcademicDepartmentToDto(IEnumerable<Department> src) {
            string str = "";
            if (src.ToList().Count == 0)
            {
                foreach (Department department in src)
                {
                    str += department.Abbrev + ", ";
                }
                str = str.Remove(str.Length - 2, 2);
            }
            return str;
        }
        
        public AutoMapperProfile()
        {
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
