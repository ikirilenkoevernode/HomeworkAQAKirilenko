using BookStore.DTO;
using BookStore.interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Tests
{
    public class BookStoreTests
    {
        private IBookAPI api;

        [OneTimeSetUp]

        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookAPI>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookAPI>();
        }

        [Test]
        public async Task TestCreateUser()
        {
            var credentials = new UserCreateBodyDTO("MrPepe", "StrongPass123!");
            var result = await api.CreateUserAsync(credentials); // "90100852-9337-4c9b-ab73-1d904f0950c7" ID
            result.Username.Should().Be("MrPepe");
        }

        [Test]
        public async Task TestGetToken()
        {
            var credentials = new UserCreateBodyDTO("MrPepe", "StrongPass123!");
            var result = await api.GetUserTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }

    }
}