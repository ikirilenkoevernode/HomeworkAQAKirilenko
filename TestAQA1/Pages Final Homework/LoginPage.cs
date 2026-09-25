using Microsoft.Playwright;
using TestAQA.Pages;

namespace TestAQA.Pages
{
    public class LoginPage : BasePage
    {
        private ILocator UsernameInput => Page.GetByTestId("username");
        private ILocator PasswordInput => Page.GetByTestId("password");
        private ILocator LoginButton => Page.GetByTestId("login-button");

        public LoginPage(IPage page) : base(page)
        {
        }

        public async Task OpenAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com");
        }

        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}