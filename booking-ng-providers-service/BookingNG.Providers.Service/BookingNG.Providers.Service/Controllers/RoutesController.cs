using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookingNG.Providers.Service.Models;
using BookingNG.Providers.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingNG.Providers.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> logger;
        private readonly IRouteProviderService routeProviderService;
        private readonly IMapper mapper;

        public RoutesController(
            IRouteProviderService routeProviderService,
            IMapper mapper,
            ILogger<RoutesController> logger)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.routeProviderService = routeProviderService;

        }

        [HttpGet]
        public async Task<IEnumerable<RouteModel>> Get()
        {
            var routes = await this.routeProviderService.GetRoutes();
            return this.mapper.Map<IEnumerable<RouteModel>>(routes);
        }
    }
}
