using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using TestAQA.Pages;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace TestAQA.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private IPlaywright _playwright = null!;
        private IBrowser _browser = null!;
        private IPage _page = null!;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _playwright.Selectors.SetTestIdAttribute("data-test");
            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    SlowMo = 600
                });

            _page = await _browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [Test]
        public async Task UserCanBuyTwoProducts()
        {
            // Arrange
            const string username = "standard_user";
            const string password = "secret_sauce";

            const string product1 = "Sauce Labs Backpack";
            const string product2 = "Sauce Labs Bike Light";

            // 1-2. Open site and login
            var loginPage = new LoginPage(_page);

            await loginPage.OpenAsync();
            await loginPage.LoginAsync(username, password);

            // 3. Check Products page
            var productsPage = new ProductsPage(_page);

            (await productsPage.IsOpenedAsync())
                .Should()
                .BeTrue();

            // 4. Add two products
            await productsPage.AddToCartAsync(product1);
            await productsPage.AddToCartAsync(product2);

            // 5. Open cart and check products
            var cartPage = await productsPage.OpenCartAsync();

            (await cartPage.ContainsProductAsync(product1))
                .Should()
                .BeTrue();

            (await cartPage.ContainsProductAsync(product2))
                .Should()
                .BeTrue();

            // 6. Checkout
            var checkoutPage = await cartPage.CheckoutAsync();

            // 7. Fill checkout form
            await checkoutPage.FillInformationAsync(
                "Pepe",
                "Test",
                "10001");

            var overviewPage = await checkoutPage.ContinueAsync();

            // 8. Check selected products
            (await overviewPage.ContainsProductAsync(product1))
                .Should()
                .BeTrue();

            (await overviewPage.ContainsProductAsync(product2))
                .Should()
                .BeTrue();

            // 9. Finish order
            var completePage = await overviewPage.FinishAsync();

            // 10. Check successful order
            (await completePage.IsOrderCompletedAsync())
                .Should()
                .BeTrue();
        }
    }
}