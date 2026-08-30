using Dapper;
using FluentAssertions;
using FluentAssertions.Execution;
using HelpClasses;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Text.Json;
using TestHomework15.DTO;
using Tests1.Interfaces.DapperTestsInterfaces;
using Tests1.Preconditions;
using Tests1.Repositories;
using Tests1617;
using Tests1617.Classes;
using Tests1617.Interfaces;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
namespace TestHomework1617
{
    public class TestUserDataHomework1617
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();
        [Test]
        public void Notify_ShouldSendEmail()
        {
            var fakeSender = new FakeEmailSender();

            var notifier = new UserNotifier(fakeSender);
            notifier.Notify(123);

            fakeSender.SentTo.Should().Be("user@mail.com");
            fakeSender.SentText.Should().Be("Hello, user 123!");
            TestContext.WriteLine($"{fakeSender.SentTo}");
            TestContext.WriteLine($"{fakeSender.SentText}");
        }
        //[Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        //[Test]
        //public async Task Test002CheckAllAdresseCount()
        //{
        //    var repo = p.Provider.GetService<IAddressRepository>();
        //    var adresses = await repo.GetAddressesAsync();
        //    adresses.Should().HaveCount(15);
        //}
        [Test]

        public async Task Test003CheckAllCategories()
        {
            var repo = p.Provider.GetService<ICategoriesRepository>();
            var adresses = await repo.GetCategoriesAsync();
            adresses.Should().HaveCount(6);
        }

        [Test]
        public async Task Test004CheckProductById()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var id = 1;
            var product= await repo.GetProductById(1);
            product.name.Should().Be("iPhone 15");
            product.description.Should().Be("Смартфон Apple");
            product.price.Should().Be(79990);
            product.stock.Should().Be(15);
            product.categoryId.Should().Be(1);
        }

        [Test]
        public async Task Test005CheckOrderByOrderId()
        {
            var repoOrder = p.Provider.GetRequiredService<IOrderRepository>();
            var repoItems = p.Provider.GetService<IOrderItemsRepository>();
            var repoProducts = p.Provider.GetService<IProductRepository>();
            var id = 1;
            var order = await repoOrder.GetOrderByOrderId(id);
            var totalPriceOrder = order.totalPrice;
            var orderItems = await repoItems.GetOrderItemsByOrderId(id);
            var PriceCounted = 0.0;
            foreach (var orderItem in orderItems)
            {
                var product = await repoProducts.GetProductById((int)orderItem.productId);
                PriceCounted = PriceCounted + product.price;
            }
            totalPriceOrder.Should().Be(PriceCounted);
        }
    }
}