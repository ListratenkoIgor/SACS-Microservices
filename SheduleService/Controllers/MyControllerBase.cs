using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SheduleModelsLib.Models;
using SheduleModelsLib.Helpers;
using SheduleService.Data;
using AutoMapper;

namespace SheduleService.Controllers
{
    public abstract class MyControllerBase : ControllerBase
    {
        protected UnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public MyControllerBase(UnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
