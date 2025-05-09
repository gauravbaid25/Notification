namespace NotificationService.Models
{
    public class Notification
    {
        public required string Type { get; set; } //e.g. SMS, Email, InApp
        public required string Receiver { get; set; } //e.g. EmailId, PhoneNumber, DeviceId
    }
}
