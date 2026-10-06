namespace TestAQA.Tests.TestData;

public class StudentFormBuilder
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _email = string.Empty;
    private string _gender = string.Empty;
    private string _mobile = string.Empty;

    public StudentFormBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public StudentFormBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public StudentFormBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public StudentFormBuilder WithGender(string gender)
    {
        _gender = gender;
        return this;
    }

    public StudentFormBuilder WithMobile(string mobile)
    {
        _mobile = mobile;
        return this;
    }

    public StudentForm Build()
    {
        return new StudentForm
        {
            FirstName = _firstName,
            LastName = _lastName,
            Email = _email,
            Gender = _gender,
            Mobile = _mobile
        };
    }
}