using RabbitMQ.Client;
using System.Text;

//Bağlantı Oluşturma
ConnectionFactory factory = new();
factory.Uri = new("amqp://localhost:5672");

//Bağlantıyı Aktifleştirme ve Kanal Açma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();


//Kuyruk Oluşturma
channel.QueueDeclare(queue: "test-queue", exclusive: false);

//Kuyruğa Mesaj Gönderme

//RabbitMq kuyruğa atacağı mesajları byte türünden kabul etmektedir.
byte[] message = Encoding.UTF8.GetBytes("Merhaba");
channel.BasicPublish(exchange: "", routingKey: "test-queue", body: message);

Console.Read();