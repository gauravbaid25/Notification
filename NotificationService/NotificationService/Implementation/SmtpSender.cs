using NotificationService.Interface;
using NotificationService.Models;
namespace NotificationService.Implementation
{
    public class SmtpSender : ISender
    {
        private readonly HealthAnomalies _anomalies;
        private readonly IConfiguration _configuration;
        private readonly Notification _notification;
        /// <summary>
        /// SmtpSender constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="notification"></param>
        /// <param name="anomalies"></param>
        public SmtpSender(IConfiguration configuration, Notification notification, HealthAnomalies anomalies)
        {
            _anomalies = anomalies;
            _configuration = configuration;
            _notification = notification;
        }
        /// <summary>
        /// Send Email using SMTP.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SendPayload()
        {
            throw new NotImplementedException();
        }
    }
}
