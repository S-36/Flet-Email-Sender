namespace Backend_Flet.Email_sender.Model
{
    public class EmailRequest
    {
        public string to { get; set; } = string.Empty;
        public string subject { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    }
}