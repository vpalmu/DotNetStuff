namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _configuration = configuration;

            _mailTo = _configuration["mailSettings:mailToAddress"];
            _mailFrom = _configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            // send email - output to console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                              $"with {nameof(LocalMailService)}.");

            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
