using System;
using FluentAssertions;
using NSubstitute;
using Serilog;
using SimpleService.Controllers;
using SimpleService.Services;
using Xunit;

namespace SimpleService.Tests.Controllers
{
    public class HealthControllerTests
    {
        private readonly HealthController _subject;
        private readonly IApplicationHealthService _applicationHealthService;
        private readonly IServerHealthService _serverHealthService;
        private readonly IDatabaseHealthService _databaseHealthService;
        private readonly IDateTimeService _dateTimeService;

        public HealthControllerTests()
        {
            _applicationHealthService = Substitute.For<IApplicationHealthService>();
            _serverHealthService = Substitute.For<IServerHealthService>();
            _databaseHealthService = Substitute.For<IDatabaseHealthService>();
            _dateTimeService = Substitute.For<IDateTimeService>();
            _subject = new HealthController(_applicationHealthService,
                _serverHealthService,
                _databaseHealthService,
                _dateTimeService,
                Substitute.For<ILogger>());
        }

        [Fact]
        public void GetResultShouldNotBeNull()
        {
            // arrange

            // act
            var result = _subject.Get();

            // assert
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PassedApplicationHealthShouldBeIReturnedByGet(bool value)
        {
            // arrange
            _applicationHealthService.IsApplicationHealthy().Returns(value);

            // act
            var result = _subject.Get();

            // assert
            result.ApplicationHealthy.Should().Be(value);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PassedServerHealthShouldBeReturnedByGet(bool value)
        {
            // arrange
            _serverHealthService.IsServerHealthy().Returns(value);

            // act
            var result = _subject.Get();

            // assert
            result.ServerHealthy.Should().Be(value);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PassedDatabaseHealthShouldBeReturnedByGet(bool value)
        {
            // arrange
            _databaseHealthService.IsDatabaseHealthy().Returns(value);

            // act
            var result = _subject.Get();

            // assert
            result.DatabaseHealthy.Should().Be(value);
        }

        [Fact]
        public void PassedTimestampShouldBeReturnedByGet()
        {
            // arrange
            var dateTime = new DateTime(1989, 3, 26, 18, 00, 00);
            _dateTimeService.Now().Returns(dateTime);

            // act
            var result = _subject.Get();

            // assert
            result.Timestamp.Should().Be(dateTime);
        }

        [Fact]
        public void PassedHostnameShouldBeReturnedByGet()
        {
            // arrange
            const string hostname = "theHost";
            _serverHealthService.Hostname.Returns(hostname);

            // act
            var result = _subject.Get();

            // assert
            result.Hostname.Should().Be(hostname);
        }
    }
}
