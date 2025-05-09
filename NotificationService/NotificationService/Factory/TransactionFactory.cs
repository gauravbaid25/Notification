using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Factory
{
    public class TransactionFactory : ITransactionFactory
    {
        private readonly IConfiguration _configuration;
        public TransactionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ITransaction CreateSender(Notification notification, HealthAnomalies anomalies)
        {
            switch (notification.Type)
            {
                case Utility.Constants.Email:
                    return new EmailFactory(_configuration, notification, anomalies);
                case Utility.Constants.Sms:
                    return new EmailFactory(_configuration, notification, anomalies);
                case Utility.Constants.InApp:
                    return new EmailFactory(_configuration, notification, anomalies);
                default:
                    return new UnknownFactory(_configuration, notification, anomalies);
            }
        }
    }
}
