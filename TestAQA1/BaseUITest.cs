using Microsoft.Playwright;
using NUnit.Framework;

namespace TestAQA.Tests
{
    public abstract class BaseUITest
    {
        protected IPlaywright Playwright = null!;
        protected IBrowser Browser = null!;
        protected IPage Page = null!;

        [SetUp]
        public async Task SetUp()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Playwright.Selectors.SetTestIdAttribute("data-test");
            Browser = await Playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    SlowMo = 300
                });

            Page = await Browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}