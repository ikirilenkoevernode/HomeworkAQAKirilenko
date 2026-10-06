using FluentAssertions;
using NUnit.Framework;
using TestAQA.Tests.Pages;
using TestAQA.Tests.TestData;

namespace TestAQA.Tests;

[TestFixture]
public class StudentRegistrationTests : BaseUITest
{
    [Test]
    public async Task StudentRegistration_ShouldBeSuccessful()
    {
        // Arrange
        var student = new StudentFormBuilder()
            .WithFirstName("John")
            .WithLastName("Smith")
            .WithEmail("john.smith@example.com")
            .WithGender("Male")
            .WithMobile("1234567890")
            .Build();

        var registrationPage = new StudentRegistrationPage(Page);

        // Act
        await registrationPage.OpenAsync();

        await registrationPage.FillFormAsync(student);

        await registrationPage.SubmitAsync();

        // Assert
        var message = await registrationPage.GetThanksMessageAsync();

        message.Should().Contain("Thanks for submitting the form");
    }
}