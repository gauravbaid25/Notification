using System.Text;
using System.Text.Json;
using MQTTnet;
using NotificationService.Interface;
using NotificationService.Models;
using NotificationService.Utility;

namespace NotificationService.Consumer
{
    public class MqttConsumerService : IHostedService
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttSettings _mqttSettings;
        private readonly ITransactionFactory _transactionFactory;

        public MqttConsumerService(IConfiguration configuration, ITransactionFactory transactionFactory)
        {
            var factory = new MqttClientFactory();
            _mqttClient = factory.CreateMqttClient();
            _transactionFactory = transactionFactory;
            _mqttSettings = configuration.GetSection("MqttSettings").Get<MqttSettings>()
                    ?? throw new ArgumentNullException(nameof(_mqttSettings), "MqttSettings configuration is missing.");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var options = new MqttClientOptionsBuilder()
           .WithTcpServer(_mqttSettings.BrokerAddress, _mqttSettings.Port)
           .WithClientId(_mqttSettings.ClientId)
           .Build();

            _mqttClient.ApplicationMessageReceivedAsync += async e =>
            {
                var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                try
                {
                    var anomaly = JsonSerializer.Deserialize<HealthAnomalies>(message);
                    if (anomaly != null)
                    {
                        Console.WriteLine($"Received anomaly for Patient: {anomaly?.PatientId}, Type: {anomaly?.AnomalyType}, Severity: {anomaly?.Severity}");
                        //Fetch Notification Details from Database. Code not implemented here.
                        Notification notification = new Notification() { Type = Constants.InApp, Receiver = "Device Id" };
                        _transactionFactory.CreateSender(notification, anomaly).GetInstance().SendPayload();
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to parse anomaly data: {ex.Message}");
                }
            };

            await _mqttClient.ConnectAsync(options, cancellationToken);
            await _mqttClient.SubscribeAsync(_mqttSettings.Topic);

            Console.WriteLine($"Subscribed to '{_mqttSettings.Topic}' topic.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _mqttClient.DisconnectAsync();
        }
    }
}
