using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using DataService.Data.Repositories;

namespace DataService.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private bool _disposed = false;

        private DepartmentsRepository _departmentsRepository;
        private EducationFormsRepository _educationFormsRepository;
        private EmployeesRepository _employeesRepository;
        private FacultiesRepository _facultiesRepository;
        private SpecialitiesRepository _specialitiesRepository;
        private StudentsGroupsRepository _studentsGroupsRepository;
        private StudentsRepository _studentsRepository;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public DepartmentsRepository Departments => _departmentsRepository = _departmentsRepository ?? new DepartmentsRepository(_applicationDbContext);
        public EducationFormsRepository EducationForms => _educationFormsRepository = _educationFormsRepository ?? new EducationFormsRepository(_applicationDbContext);
        public EmployeesRepository Employees => _employeesRepository = _employeesRepository ?? new EmployeesRepository(_applicationDbContext);
        public FacultiesRepository Faculties => _facultiesRepository = _facultiesRepository ?? new FacultiesRepository(_applicationDbContext);
        public SpecialitiesRepository Specialities => _specialitiesRepository = _specialitiesRepository ?? new SpecialitiesRepository(_applicationDbContext);
        public StudentsGroupsRepository StudentsGroups => _studentsGroupsRepository = _studentsGroupsRepository ?? new StudentsGroupsRepository(_applicationDbContext);
        public StudentsRepository Students => _studentsRepository = _studentsRepository ?? new StudentsRepository(_applicationDbContext);

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _applicationDbContext.Database.BeginTransaction();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
                _disposed = true;
            }
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
