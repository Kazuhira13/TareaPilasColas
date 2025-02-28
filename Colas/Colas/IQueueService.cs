using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    public interface IQueueService
    {
        void Enqueue(string message);
        string Dequeue();
    }
}
