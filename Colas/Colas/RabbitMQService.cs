using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Amazon.SQS.Model;

namespace Colas
{
    public class RabbitMQService : IQueueService
    {

        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Enqueue(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            Console.WriteLine($"[RabbitMQ] Mensaje enviado: {message}");
        }

        public string Dequeue()
        {
            var result = channel.BasicGet(QueueName, true);
            if (result == null)
            {
                return "[RabbitMQ] La cola está vacía";
            }
            return $"[RabbitMQ] Mensaje recibido: {Encoding.UTF8.GetString(result.Body.ToArray())}";
        }
    }
}

