using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace HealthCheck.Tests.API
{
    public class HealthCheckTests
    {
        protected HttpClient Client;

        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            var hostBuilder = new WebApplicationFactory<Startup>();
            Client = hostBuilder.CreateDefaultClient();
        }

        [Test]
        public async Task ShouldReturnHealthy()
        {
            var response = await Client.GetAsync("health");

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotBeNullOrEmpty();
            content.Should().Be("Healthy");
        }
    }
}