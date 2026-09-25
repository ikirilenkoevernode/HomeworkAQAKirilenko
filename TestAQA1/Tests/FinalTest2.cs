using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using TestAQA.Tests;

namespace TestAQA.Tests
{
    [TestFixture]
    public class SelectMenuTests : BaseUITest
    {
        [Test]
        public async Task SelectOne_ShouldSelectProf()
        {
            // 1. Open page
            await Page.GotoAsync(
                "https://demoqa.com/select-menu");

            // 2. Open dropdown
            await Page
                .Locator("#selectOne")
                .ClickAsync();

            // 3. Select Prof.
            await Page
                .GetByText("Prof.", new() { Exact = true })
                .ClickAsync();

            // 4. Check selected option
            var selectedOption = await Page
                .Locator("#selectOne")
                .TextContentAsync();

            selectedOption.Should().Contain("Prof.");
        }
    }
}