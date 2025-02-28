using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Colas
{
    public class AmazonSQSService : IQueueService
    {
        private const string QueueUrl = "https://sqs.us-east-2.amazonaws.com/160885292471/Ejemplocola"; 
        private readonly AmazonSQSClient sqsClient;

        public AmazonSQSService()
        {
            sqsClient = new AmazonSQSClient();
        }

        public void Enqueue(string message)
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = QueueUrl,
                MessageBody = message
            };
            sqsClient.SendMessageAsync(sendMessageRequest).Wait();
            Console.WriteLine($"[Amazon SQS] Mensaje enviado: {message}");
        }

        public string Dequeue()
        {
            var receiveMessageRequest = new ReceiveMessageRequest { QueueUrl = QueueUrl, MaxNumberOfMessages = 1 };
            var response = sqsClient.ReceiveMessageAsync(receiveMessageRequest).Result;
            if (response.Messages.Count == 0)
            {
                return "[Amazon SQS] La cola está vacía";
            }

            var message = response.Messages[0];
            sqsClient.DeleteMessageAsync(QueueUrl, message.ReceiptHandle).Wait();
            return $"[Amazon SQS] Mensaje recibido: {message.Body}";
        }
    }
}
