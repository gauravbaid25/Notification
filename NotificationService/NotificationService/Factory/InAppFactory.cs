using Microsoft.Extensions.Configuration;
using NotificationService.Implementation;
using NotificationService.Interface;
using NotificationService.Models;

namespace NotificationService.Factory
{
    public class InAppFactory : ITransaction
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;
        private readonly string _type;
        public InAppFactory(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
            _type = configuration.GetValue<string>("ServiceConfig:InAppConfig:SnsInApp")
                ?? throw new ArgumentNullException(nameof(_type), "In App provider not configured.");
        }

        public ISender GetInstance()
        {
            switch (_type)
            {
                case Utility.Constants.SnsInApp:
                    return new SnsInAppNotification(_configuration, _notification, _anomalies);
                default:
                    throw new NotImplementedException("Invalid In App Notification Provider configured.");
            }
        }
    }
}
