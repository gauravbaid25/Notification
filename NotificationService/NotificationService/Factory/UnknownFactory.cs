using NotificationService.Implementation;
using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Factory
{
    public class UnknownFactory : ITransaction
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;
        public UnknownFactory(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
        }

        public ISender GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
