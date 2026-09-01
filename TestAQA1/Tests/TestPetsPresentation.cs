using Microsoft.Extensions.DependencyInjection;
using Pets;
using Pets.interfaces;
using FluentAssertions;
using Refit;
using TestsPets.DTO;
using helpers.classes;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
namespace TestsPets
{
    public class PetsRefitTests
    {
        private IPetAPI api;

        [OneTimeSetUp]

        public void Setup()
        {
            var services = new ServiceCollection();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
            };

            services.AddRefitClient<IPetAPI>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://petstoreapi.com/v1");
                })
                .ConfigurePrimaryHttpMessageHandler(() => handler);

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IPetAPI>();
        }

        [Test]
        public async Task TestGet()
        {
            var result = await api.GetAllPetsAsync();
            result.Data.Should().HaveCount(20);
        }

        [Test]
        public async Task TestGetRandomPetFromPetList()
        {
            var pets = await api.GetAllPetsAsync();
            var randomPet = RandomizerHelper.GetRandomItem(pets.Data);
            var result = await api.GetPetByIdAsync(randomPet.Id);
            result.Should().BeEquivalentTo(randomPet);
        }

        [Test]
        public async Task TestGetPetsByFilters()
        {
            var pets = await api.GetAllPetsFilteredByAgeMinAndLimitedAsync(5,10);
            var result = pets.Data;
            foreach(var pet in result)
            {
                TestContext.WriteLine($"{pet}");
                pet.AgeMonths.Should().BeGreaterThanOrEqualTo(5);
            }
            bool res = result.All(p => p.AgeMonths >= 5);
            res.Should().BeTrue(); 
        }
    }
}