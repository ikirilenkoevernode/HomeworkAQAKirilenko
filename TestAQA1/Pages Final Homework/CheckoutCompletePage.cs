using Microsoft.Playwright;
using TestAQA.Pages;

namespace TestAQA.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private ILocator ThankYouMessage =>
            Page.GetByText(
                "Thank you for your order!",
                new() { Exact = true });

        public CheckoutCompletePage(IPage page) : base(page)
        {
        }

        public async Task<bool> IsOrderCompletedAsync()
        {
            return await ThankYouMessage.IsVisibleAsync();
        }
    }
}