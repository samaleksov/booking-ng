using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingNG.Providers.Service.Services.Models;

namespace BookingNG.Providers.Service.Services.Interfaces
{
    public interface IRouteProviderService
    {
        public Task<IEnumerable<Route>> GetRoutes();
    }
}
