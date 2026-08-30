using Tests1617.Interfaces;
namespace Tests1617.Classes
{


public class    FakeEmailSender : IEmailSender
{
    public string? SentTo { get; private set; }
    public string? SentText { get; private set; }
    public void Send(string to, string text)
    {
        SentTo = to;
        SentText = text;
    }
}
}