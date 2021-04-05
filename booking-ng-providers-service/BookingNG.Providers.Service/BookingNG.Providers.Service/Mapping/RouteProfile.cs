using System;
using AutoMapper;
using BookingNG.Providers.Service.Models;
using BookingNG.Providers.Service.Services.Models;

namespace BookingNG.Providers.Service.Mapping
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteModel>();
        }
    }
}
