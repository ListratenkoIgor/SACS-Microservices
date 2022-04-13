using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SheduleModelsLib.Models;
using Interfaces.Models;

namespace SheduleService.Data.Repositories
{
    public class EducationFormsRepository: RepositoryBase<EducationForm>
    {
        public EducationFormsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }
    }
}