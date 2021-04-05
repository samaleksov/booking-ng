using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingNG.Providers.Service.Services.Interfaces;
using BookingNG.Providers.Service.Services.Models;

namespace BookingNG.Providers.Service.Services
{
    public class RouteProviderService : IRouteProviderService
    {
        public async Task<IEnumerable<Route>> GetRoutes()
        {
            var result = new List<Route>();

            result.AddRange(await FetchRoutesFromFirstProvider());
            result.AddRange(await FetchRoutesFromSecondProvider());
            return result;
        }

        // These would be done using external http services instead of being mocked
        private async Task<IEnumerable<Route>> FetchRoutesFromFirstProvider()
        {
            return await Task.FromResult(new List<Route>
            {
                new Route
                {
                     Airline = "XYZAirline",
                     CodeShare = "XYZ123",
                     DestinationAirport = "BGY",
                     SourceAirport = "MPX",
                     Equipment = "F0F0X0F0X",
                     Stops = 1
                }
            });
        }

        private async Task<IEnumerable<Route>> FetchRoutesFromSecondProvider()
        {
            return await Task.FromResult(new List<Route>
            {
                new Route
                {
                     Airline = "XYZAirline",
                     CodeShare = "XYZ124",
                     DestinationAirport = "BGY",
                     SourceAirport = "LIN",
                     Equipment = "F0F0X0F0X",
                     Stops = 0
                }
            });
        }
    }
}
