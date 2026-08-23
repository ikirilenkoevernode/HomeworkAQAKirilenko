using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TestAQA1;
namespace TestAQA2
{
    public class Class1
    {
        private IUserApi api;
        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://reqres.in/api");
            });
            var provider = services.BuildServiceProvider();

            api = provider.GetRequiredService<IUserApi>();
        }
        [Test]
        public async Task Test1()
        {
            var result = await api.GetUserAync(2);
            Assert.That(result.Data.ID, Is.EqualTo(2));
        }
        [Test]
        public async Task Test2()
        {
            var request = new CreateUserRequestDTO { Name = "John", Job = "AppleCons" };
            var response = await api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo("John"));
            Assert.That(response.Job, Is.EqualTo("AppleCons"));
        }
        [Test]
        public async Task Test3()
        {
            var deleteResult = await api.DeleteUserAsync(2);
            Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That((int)deleteResult.StatusCode, Is.EqualTo(204));
        }
    }

}


