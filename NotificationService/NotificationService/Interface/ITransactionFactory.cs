using NotificationService.Models;

namespace NotificationService.Interface
{
    public interface ITransactionFactory
    {
        ITransaction CreateSender(Notification notification, HealthAnomalies anomalies);
    }
}
