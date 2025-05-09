using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Configuration;
using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Implementation
{
    public class SnsInAppNotification : ISender
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;
        private readonly string _topic;
        private readonly AmazonSimpleNotificationServiceClient _snsClient = new AmazonSimpleNotificationServiceClient();
        public SnsInAppNotification(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
            _topic = configuration.GetValue<string>("ServiceConfig:InAppConfig:SnsInApp")
                    ?? throw new ArgumentNullException(nameof(_topic), "InApp provider not configured.");
        }
        public bool SendPayload()
        {
            try
            {
                var request = new PublishRequest
                {
                    TopicArn = _topic,
                    Message = _anomalies.AnomalyType,
                    TargetArn = "Device Specific Target End Point"
                };
                _snsClient.PublishAsync(request);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
