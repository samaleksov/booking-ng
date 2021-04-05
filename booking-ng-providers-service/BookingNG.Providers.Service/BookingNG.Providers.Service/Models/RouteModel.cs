using System;
using System.ComponentModel.DataAnnotations;

namespace BookingNG.Providers.Service.Models
{
    public class RouteModel
    {
        [Required]
        public string Airline { get; init; }

        [Required]
        public string SourceAirport { get; init; }

        [Required]
        public string DestinationAirport { get; init; }

        [Required]
        public string CodeShare { get; init; }

        [Required]
        public int? Stops { get; init; }

        public string Equipment { get; init; }
    }
}
