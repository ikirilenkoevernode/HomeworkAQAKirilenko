using FluentAssertions;
using NUnit.Framework;
using Microsoft.Playwright;
namespace PlaywrightFramework.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public async Task Login_ShouldBeSuccessful()
    {
        // Arrange
        var username = Page.GetByTestId("username");
        var password = Page.GetByTestId("password");
        var loginButton = Page.GetByTestId("login-button");

        // Act
        await username.FillAsync("standard_user");
        await password.FillAsync("secret_sauce");

        await loginButton.ClickAsync();

        // Assert
        var products = Page.GetByText("Products");

        await Assertions.Expect(products).ToBeVisibleAsync();
    }
}