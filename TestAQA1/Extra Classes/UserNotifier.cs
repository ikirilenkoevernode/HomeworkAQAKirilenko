using Tests1617.Interfaces;
namespace Tests1617.Classes { 
public class UserNotifier
{
    private readonly IEmailSender _sender;

    public UserNotifier(IEmailSender sender)
    {
        _sender = sender;
    }

    public void Notify(int userId)
    {
        _sender.Send("user@mail.com", $"Hello, user {userId}!");
    }
}
}