using System;
using AutoMapper;
using BookingNG.Providers.Service.Mapping;

namespace BookingNG.Providers.Service.Tests.Fixtures
{
    public class MappingFixture
    {
        public MappingFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<RouteProfile>(); });
            Mapper = ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}
