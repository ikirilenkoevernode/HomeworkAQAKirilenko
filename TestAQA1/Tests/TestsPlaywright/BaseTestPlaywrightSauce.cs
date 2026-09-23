using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Playwright;
namespace PlaywrightFramework.Tests;

public class BaseTest
{
    protected PlaywrightFixture Fixture = null!;
    protected IPage Page => Fixture.Page;

    [SetUp]
    public async Task SetUp()
    {
        Fixture = new PlaywrightFixture();

        await Fixture.InitializeAsync();

        await Page.GotoAsync("https://www.saucedemo.com/");
    }

    [TearDown]
    public async Task TearDown()
    {
        await Fixture.DisposeAsync();
    }
}