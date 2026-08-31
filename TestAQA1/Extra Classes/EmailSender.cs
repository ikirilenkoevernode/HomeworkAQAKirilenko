using System;
using Tests1617.Interfaces;
namespace Tests1617.Classes
{

    public class EmailSender : IEmailSender
    {
        public void Send(string to, string text)
        {
            Console.WriteLine($"Sending mail to {to}: {text}");
        }
    }

}
