using Microsoft.Playwright;
using TestAQA.Pages;

namespace TestAQA.Pages
{
    public class ProductsPage : BasePage
    {
        private ILocator ProductsTitle =>
            Page.GetByText("Products", new() { Exact = true });

        private ILocator CartButton =>
            Page.GetByTestId("shopping-cart-link");

        private ILocator AddToCartButton(string productName) =>
            Page
                .Locator(".inventory_item")
                .Filter(new LocatorFilterOptions
                {
                    HasText = productName
                })
                .GetByRole(
                    AriaRole.Button,
                    new() { Name = "Add to cart" });

        public ProductsPage(IPage page) : base(page)
        {
        }

        public async Task<bool> IsOpenedAsync()
        {
            return await ProductsTitle.IsVisibleAsync();
        }

        public async Task AddToCartAsync(string productName)
        {
            await AddToCartButton(productName).ClickAsync();
        }

        public async Task<CartPage> OpenCartAsync()
        {
            await CartButton.ClickAsync();

            return new CartPage(Page);
        }
    }
}