using Microsoft.Playwright;
using TestAQA.Pages;

namespace TestAQA.Pages
{
    public class CheckoutPage : BasePage
    {
        private ILocator FirstNameInput =>
            Page.GetByTestId("firstName");

        private ILocator LastNameInput =>
            Page.GetByTestId("lastName");

        private ILocator PostalCodeInput =>
            Page.GetByTestId("postalCode");

        private ILocator ContinueButton =>
            Page.GetByTestId("continue");

        public CheckoutPage(IPage page) : base(page)
        {
        }

        public async Task FillInformationAsync(
            string firstName,
            string lastName,
            string postalCode)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await PostalCodeInput.FillAsync(postalCode);
        }

        public async Task<CheckoutOverviewPage> ContinueAsync()
        {
            await ContinueButton.ClickAsync();

            return new CheckoutOverviewPage(Page);
        }
    }
}