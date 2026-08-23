
namespace TestAQA3
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using System.Text.Json;
    using TestAQA3.DTO;
    public class OrderJsonTests
    {
        private OrderDTO order;
        [OneTimeSetUp]
        public void Setup()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "OrderData.json");
            string json = File.ReadAllText(path);
            order = JsonSerializer.Deserialize<OrderDTO>(json);
        }

        [Test]
        public void Test1_CheckItemsIsNotNull()
        {
            foreach (var item in order.Items)
            {
                TestContext.WriteLine($" {item.ProductId} | {item.Quantity} | {item.Price}");
            }
            order.Items.Should().NotBeNull();
            order.Items.Should().HaveCount(3);
        }

        [Test]
        public void Test2_CheckSumOfItems()
        {
            var sum = order.Items.Select(item => item.Quantity * item.Price).Sum();
            sum.Should().Be(order.Summary.ItemsTotal);
        }
        [Test]

        public void Test3_CheckElectronicQuantity()
        {
            var hasElectronicsCaregory = order.Items.Where(item => item.Category == "Electronics").ToList();
            using (new AssertionScope())
            {


                hasElectronicsCaregory.Should().OnlyContain(item => item.Category == "Electronics");
                hasElectronicsCaregory.Should().HaveCount(2);
            }
        }
    }
}