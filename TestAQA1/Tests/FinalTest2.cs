using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;

namespace TestAQA.Tests
{
    [TestFixture]
    public class SelectMenuTests
    {
        private IPlaywright _playwright = null!;
        private IBrowser _browser = null!;
        private IPage _page = null!;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    SlowMo = 500
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
        public async Task SelectOne_ShouldSelectProf()
        {
            // 1. Open page
            await _page.GotoAsync(
                "https://demoqa.com/select-menu");

            // 2. Open dropdown
            await _page
                .Locator("#selectOne")
                .ClickAsync();

            // 3. Select Prof.
            await _page
                .GetByText("Prof.", new() { Exact = true })
                .ClickAsync();

            // 4. Check selected option
            var selectedOption = await _page
                .Locator("#selectOne")
                .GetByText("Prof.", new() { Exact = true })
                .TextContentAsync();

            selectedOption.Should().Be("Prof.");
        }
    }
}