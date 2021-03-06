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
using Microsoft.Extensions.DependencyInjection;

namespace SheduleService.Controllers
{
    public abstract class MyControllerBase : ControllerBase
    {
        protected UnitOfWork _unitOfWork;
        protected IMapper _mapper;
        protected IServiceScopeFactory _serviceScopeFactory;
        public MyControllerBase(UnitOfWork unitOfWork, IMapper mapper, IServiceScopeFactory serviceScopeFactory) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
        }
    }
}
