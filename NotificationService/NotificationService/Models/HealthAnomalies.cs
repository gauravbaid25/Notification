namespace NotificationService.Models
{
    public class HealthAnomalies
    {
        public required string PatientId { get; set; }
        public DateTime TimeStamp { get; set; }
        public required string AnomalyType { get; set; }
        public required string Severity { get; set; }
        public required string Details { get; set; }
    }
}
