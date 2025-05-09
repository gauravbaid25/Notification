namespace NotificationService.Models
{
    public class MqttSettings
    {
        public string BrokerAddress { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
    }
}
