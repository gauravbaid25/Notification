using Microsoft.Extensions.Configuration;
using NotificationService.Implementation;
using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Factory
{
    public class EmailFactory : ITransaction
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;
        private readonly string _type;
        public EmailFactory(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
            _type = configuration.GetValue<string>("ServiceConfig:EmailConfig:EmailProviderType")
                ?? throw new ArgumentNullException(nameof(_type), "Email provider not configured.");
        }

        public ISender GetInstance()
        {
            switch (_type)
            {
                case Utility.Constants.Smtp:
                    return new SmtpSender(_configuration, _notification, _anomalies);
                case Utility.Constants.SnsEmail:
                    return new SnsEmailSender(_configuration, _notification, _anomalies);
                default:
                    throw new NotImplementedException("Invalid Email Provider configured.");
            }
        }
    }
}
