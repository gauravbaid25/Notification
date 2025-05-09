using NotificationService.Implementation;
using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Factory
{
    public class SmsFactory : ITransaction
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;
        private readonly string _type;
        public SmsFactory(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
           _type = configuration.GetValue<string>("ServiceConfig:SMSConfig:SMSProviderType")
                ?? throw new ArgumentNullException(nameof(_type), "SMS provider not configured.");
        }

        public ISender GetInstance()
        {
            switch (_type)
            {
                case Utility.Constants.Twilio:
                    return new SmtpSender(_configuration, _notification, _anomalies);
                case Utility.Constants.SnsSms:
                    return new SnsSmsSender(_configuration, _notification, _anomalies);
                default:
                    throw new NotImplementedException("Invalid SMS Notification Provider configured.");
            }
        }
    }
}
