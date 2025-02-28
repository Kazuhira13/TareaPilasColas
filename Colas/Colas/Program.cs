using Colas;
namespace Colas
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IQueueService queueService = new AmazonSQSService(); //para cambiar RabbitMQService();
            QueueManager queueManager = new QueueManager(queueService);

            
            Console.Write("Ingrese un mensaje: ");
            string message = Console.ReadLine();

            
            queueManager.AddMessage(message);
            Console.WriteLine("Mensaje ingresado y enviado a la cola.");

            
            string receivedMessage = queueManager.GetMessage();
            Console.WriteLine("Mensaje recibido desde la cola: " + receivedMessage);

            
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
