using Microsoft.Playwright;
using TestAQA.Pages;

namespace TestAQA.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private ILocator FinishButton =>
            Page.GetByRole(AriaRole.Button, new()
            {
                Name = "Finish"
            });

        public CheckoutOverviewPage(IPage page) : base(page)
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

        public async Task<CheckoutCompletePage> FinishAsync()
        {
            await FinishButton.ClickAsync();

            return new CheckoutCompletePage(Page);
        }
    }
}
