using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet;


namespace Physim.Exporter.Clients.MQTT
{

    public class MQTTClient : Client
    {
        string url = "www.example.com";

        MQTTOptions options;
        IMqttClient mqttClient;

        public MQTTClient() { }

        public MQTTClient(string url)
        {
            this.url = url;
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();
        }

        public async Task connectViaTCP(string settingsfile)
        {
            connectViaTCP(MQTTOptions.FromString(File.ReadAllText(settingsfile)));
        }
        public async Task connectViaTCP(MQTTOptions options)
        {
            this.options = options;

            url = options.URL;
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();
            connectViaTCP(options.URL, options.port, options.username, options.password);
        }

        public async Task connectViaTCP(string url, int port, string username, string password)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(url, port) // Port is optional
                .WithCredentials(username, password)
                .Build();

            await mqttClient.ConnectAsync(options, CancellationToken.None);
        }


        public async void publish(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                 .WithPayload(payload)
                .WithRetainFlag()
                 .Build();

            await mqttClient.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken
        }


        public override void Send(string data)
        {
            publish(options.topic, data);
        }


    }
}