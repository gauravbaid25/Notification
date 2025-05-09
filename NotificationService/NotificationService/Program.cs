using NotificationService.Consumer;
using NotificationService.Factory;
using NotificationService.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITransactionFactory, TransactionFactory>();
builder.Services.AddHostedService<MqttConsumerService>();


var app = builder.Build();
app.Run();
