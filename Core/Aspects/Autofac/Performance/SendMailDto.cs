namespace Core.Aspects.Autofac.Performance
{
    public class SendMailDto
    {
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SMTP { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string Email2 { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}