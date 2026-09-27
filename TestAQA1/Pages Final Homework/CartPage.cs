using Microsoft.Playwright;
using TestAQA.Pages;

namespace TestAQA.Pages
{
    public class CartPage : BasePage
    {
        private ILocator CheckoutButton =>
            Page.GetByRole(AriaRole.Button, new()
            {
                Name = "Checkout"
            });

        public CartPage(IPage page) : base(page)
        {
        }

        public async Task<bool> ContainsProductAsync(string productName)
        {
            var product = Page
                .Locator(".cart_item")
                .Filter(new LocatorFilterOptions
                {
                    HasText = productName
                });

            return await product.IsVisibleAsync();
        }

        public async Task<CheckoutPage> CheckoutAsync()
        {
            await CheckoutButton.ClickAsync();

            return new CheckoutPage(Page);
        }
    }
}