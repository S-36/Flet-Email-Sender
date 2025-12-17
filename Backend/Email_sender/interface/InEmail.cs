namespace Backend_Flet.Email_sender.Interface
{
    public interface InEmail
    {
        Task SendEmail(string to, string subject, string body);
    }
}