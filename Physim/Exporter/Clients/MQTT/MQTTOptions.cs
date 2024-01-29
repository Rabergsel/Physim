namespace Physim.Exporter.Clients.MQTT
{
    public class MQTTOptions
    {
        public MQTTOptions(string uRL, int port, string username, string password)
        {
            URL = uRL;
            this.port = port;
            this.username = username;
            this.password = password;
        }

        public string URL { get; set; } = "www.example.com";
        public int port { get; set; } = 0;

        public string username { get; set; } = "username";
        public string password { get; set; } = "password";

        public string topic { get; set; } = "./";

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }

        public static MQTTOptions FromString(string s)
        {
            return System.Text.Json.JsonSerializer.Deserialize<MQTTOptions>(s);
        }

    }
}