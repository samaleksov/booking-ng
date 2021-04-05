using System;
namespace BookingNG.Providers.Service.Services.Models
{
    public class Route
    {
        public string Airline { get; init; }

        public string SourceAirport { get; init; }

        public string DestinationAirport { get; init; }

        public string CodeShare { get; init; }

        public int? Stops { get; init; }

        public string Equipment { get; init; }
    }
}
