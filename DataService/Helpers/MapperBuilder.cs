using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Data;
using AutoMapper;
using Interfaces.Models;
using Interfaces.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataService.Helpers
{
    public class MapperBuilder
    {
        private readonly ApplicationDbContext _context;
        public MapperBuilder(ApplicationDbContext context)
        {
            _context = context;
        }
        public MapperBuilder(){}
        public Mapper Build()
        {
            var expression = new MapperConfigurationExpression();
            ConfigureMapper(expression);
            var config = new MapperConfiguration(expression);
            return new Mapper(config);
        }
        private List<int> MapAcademicDepartmentToDto(IEnumerable<Department> src)
        {
            List<int> vs = new List<int>();
            foreach (Department department in src) {
                vs.Add(department.Id);
            }
            return vs;
            /*
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
            */
        }
        private void ConfigureMapper(MapperConfigurationExpression expression)
        {
            /*
            expression.CreateMap<Department, DepartmentDto>().ReverseMap();
            expression.CreateMap<EducationForm, EducationFormDto>().ReverseMap();
            expression.CreateMap<Employee, EmployeeDto>().ReverseMap();
            expression.CreateMap<Faculty, FacultyDto>().ReverseMap();
            expression.CreateMap<Speciality, SpecialityDto>().ReverseMap();
            expression.CreateMap<Student, StudentDto>().ReverseMap();
            expression.CreateMap<StudentsGroup, StudentsGroupDto>().ReverseMap();
            
            expression.CreateMap<Department, DepartmentDto>().ReverseMap();
            expression.CreateMap<EducationForm, EducationFormDto>().ReverseMap();
            expression.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.AcademicDepartment, opt => opt.MapFrom(src => MapAcademicDepartmentToDto(src.AcademicDepartment)));
            expression.CreateMap<Faculty, FacultyDto>().ReverseMap();
            expression.CreateMap<Speciality, SpecialityDto>()
                .ForMember(dest => dest.EducationFormId, opt => opt.MapFrom(src => src.EducationForm.Id))
                .ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Faculty.Id));
            expression.CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Group.Id));
            expression.CreateMap<StudentsGroup, StudentsGroupDto>()
                .ForMember(dest => dest.SpecialityId, opt => opt.MapFrom(src => src.Id));
            expression.CreateMap<EmployeeDto, Employee>();
            expression.CreateMap<SpecialityDto, Speciality>();
            expression.CreateMap<StudentDto, Student>();
            expression.CreateMap<StudentsGroupDto, StudentsGroup>();
            
            expression.CreateMap<Department, DepartmentDto>().ReverseMap();
            expression.CreateMap<EducationForm, EducationFormDto>().ReverseMap();
            expression.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.AcademicDepartment, opt => opt.MapFrom(src => MapAcademicDepartmentToDto(src.AcademicDepartment)));
            expression.CreateMap<Faculty, FacultyDto>().ReverseMap();
            expression.CreateMap<Speciality, SpecialityDto>()
                .ForMember(dest => dest.EducationFormId, opt => opt.MapFrom(src => src.EducationForm.Id))
                .ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Faculty.Id));
            expression.CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Group.Id));
            expression.CreateMap<StudentsGroup, StudentsGroupDto>()
                .ForMember(dest => dest.SpecialityId, opt => opt.MapFrom(src => src.Id));
            */
            
            expression.CreateMap<Department, DepartmentDto>().ReverseMap();
            expression.CreateMap<EducationForm, EducationFormDto>().ReverseMap();
            expression.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.AcademicDepartment, opt => opt.MapFrom(src => MapAcademicDepartmentToDto(src.AcademicDepartment)));
            expression.CreateMap<Faculty, FacultyDto>().ReverseMap();
            expression.CreateMap<Speciality, SpecialityDto>()
                .ForMember(dest => dest.EducationFormId, opt => opt.MapFrom(src => src.EducationForm.Id))
                .ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Faculty.Id));
            expression.CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Group.Id));
            expression.CreateMap<StudentsGroup, StudentsGroupDto>()
                .ForMember(dest => dest.SpecialityId, opt => opt.MapFrom(src => src.Speciality.Id));

            expression.CreateMap<EmployeeDto, Employee>()
                .IncludeAllDerived()
                .ForMember(dest => dest.AcademicDepartment, opt => opt.MapFrom(src => _context.Employees.Select(x => x.AcademicDepartment).ToList()));
            expression.CreateMap<SpecialityDto, Speciality>()
                .IncludeAllDerived()
                .ForMember(dest => dest.EducationForm, opt => opt.MapFrom(src => _context.EducationForms.Where(x=>x.Id==src.EducationFormId).FirstOrDefault()))
                .ForMember(dest=>dest.Faculty, opt => opt.MapFrom(src => _context.Faculties.Where(x => x.Id == src.FacultyId).FirstOrDefault()));
            expression.CreateMap<StudentDto, Student>()
                .IncludeAllDerived()
                .ForMember(dest=>dest.Group, opt => opt.MapFrom(src => _context.StudentsGroups.Where(x => x.Id == src.GroupId).FirstOrDefault()));
            expression.CreateMap<StudentsGroupDto, StudentsGroup>()
                .IncludeAllDerived()
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => _context.Specialities.Where(x => x.Id == src.SpecialityId).FirstOrDefault()));
            

        }
    }
}
