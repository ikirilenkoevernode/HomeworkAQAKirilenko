using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using TestAQA.Tests.TestData;

namespace TestAQA.Tests;

[TestFixture]
public class LoginTests : BaseUITest
{
    [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.ValidUsers))]
    public async Task Login_ShouldBeSuccessful(
        string username,
        string password)
    {
        await Page.GotoAsync("https://www.saucedemo.com");

        await Page.GetByTestId("username")
            .FillAsync(username);

        await Page.GetByTestId("password")
            .FillAsync(password);

        await Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Login" })
            .ClickAsync();

        var productsText = await Page
            .GetByText("Products", new() { Exact = true })
            .TextContentAsync();

        productsText.Should().Be("Products");
    }
}