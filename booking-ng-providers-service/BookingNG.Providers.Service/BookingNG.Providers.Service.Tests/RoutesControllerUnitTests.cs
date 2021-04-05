using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookingNG.Providers.Service.Controllers;
using BookingNG.Providers.Service.Services.Interfaces;
using BookingNG.Providers.Service.Services.Models;
using BookingNG.Providers.Service.Tests.Fixtures;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BookingNG.Providers.Service.Tests
{
    public class RoutesControllerUnitTests : IClassFixture<MappingFixture>
    {
        private readonly IMapper mapper;

        public RoutesControllerUnitTests(MappingFixture mappingFixture)
        {
            if (mappingFixture == null)
                throw new ArgumentNullException(nameof(mappingFixture));

            mapper = mappingFixture.Mapper;
        }


        [Fact]
        public async void ReturnsRoutesCorrectly()
        {
            var loggerMock = new Mock<ILogger<RoutesController>>();
            var routesProviderMock = new Mock<IRouteProviderService>();

            routesProviderMock.Setup(x => x.GetRoutes())
                .Returns(Task.FromResult((IEnumerable<Route>) new List<Route>()
                {
                    new Route { }
                }));

            var sut = new RoutesController(
                routesProviderMock.Object,
                this.mapper,
                loggerMock.Object
            );

            var routes = await sut.Get();

            Assert.NotEmpty(routes);
        }
    }
}
