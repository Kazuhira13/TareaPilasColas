using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    public class QueueManager
    {
        private readonly IQueueService _queueService;

        public QueueManager(IQueueService queueService)
        {
            _queueService = queueService;
        }

        
        public void AddMessage(string message)
        {
            _queueService.Enqueue(message);
        }

        
        public string GetMessage()
        {
            return _queueService.Dequeue();
        }
    }
}
