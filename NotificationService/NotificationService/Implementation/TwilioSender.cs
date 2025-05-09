using NotificationService.Models;

namespace NotificationService.Implementation
{
    public class TwilioSender
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;

        public TwilioSender(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
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
