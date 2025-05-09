using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Implementation
{
    public class SnsSmsSender : ISender
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;

        public SnsSmsSender(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
        }
        public bool SendPayload()
        {
            throw new NotImplementedException();
        }
    }
}
