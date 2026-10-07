namespace TestAQA.Tests.TestData;

public class StudentFormBuilder
{
    private readonly StudentForm student = new();

    public StudentFormBuilder WithFirstName(string firstName)
    {
        student.FirstName = firstName;
        return this;
    }

    public StudentFormBuilder WithLastName(string lastName)
    {
        student.LastName = lastName;
        return this;
    }

    public StudentFormBuilder WithEmail(string email)
    {
        student.Email = email;
        return this;
    }

    public StudentFormBuilder WithGender(string gender)
    {
        student.Gender = gender;
        return this;
    }

    public StudentFormBuilder WithMobile(string mobile)
    {
        student.Mobile = mobile;
        return this;
    }

    public StudentForm Build()
    {
        return student;
    }
}