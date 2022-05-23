using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class RabbitMQ_settings
    {
        public readonly string Username = "guest";
        public readonly string Password = "guest";
        public readonly string IPAddress = "192.168.150.128:5672";
        public readonly string QueueName = "song-queue"; 
    }
}
