using Microsoft.Playwright;
using TestAQA.Tests.TestData;

namespace TestAQA.Tests.Pages;

public class StudentRegistrationPage
{
    private readonly IPage _page;

    public StudentRegistrationPage(IPage page)
    {
        _page = page;
    }

    private ILocator FirstName =>
        _page.GetByPlaceholder("First Name");

    private ILocator LastName =>
        _page.GetByPlaceholder("Last Name");

    private ILocator Email =>
        _page.GetByPlaceholder("name@example.com");

    private ILocator Mobile =>
        _page.GetByPlaceholder("Mobile Number");

    private ILocator SubmitButton =>
        _page.GetByRole(
            AriaRole.Button,
            new() { Name = "Submit" });

    private ILocator ThanksMessage =>
        _page.GetByText(
            "Thanks for submitting the form",
            new() { Exact = false });

    public async Task OpenAsync()
    {
        await _page.GotoAsync(
            "https://demoqa.com/automation-practice-form");
    }

    public async Task FillFormAsync(StudentForm student)
    {
        await FirstName.FillAsync(student.FirstName);
        await LastName.FillAsync(student.LastName);
        await Email.FillAsync(student.Email);
        await Mobile.FillAsync(student.Mobile);

        await _page
            .GetByText(student.Gender, new() { Exact = true })
            .ClickAsync();
    }

    public async Task SubmitAsync()
    {
        await SubmitButton.ClickAsync();
    }

    public async Task<string?> GetThanksMessageAsync()
    {
        return await ThanksMessage.TextContentAsync();
    }
}