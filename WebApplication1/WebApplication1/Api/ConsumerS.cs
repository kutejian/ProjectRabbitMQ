using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


namespace WebApplication1.Api
{
    public class ConsumerS : ConsumerSI
    {
        public IModel Connection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "47.94.210.202", // RabbitMQ 服务器的主机名或 IP 地址
                Port = 5672, // RabbitMQ 默认的端口号
                UserName = "admin", // RabbitMQ 用户名
                Password = "123456" // RabbitMQ 密码
            };
            var connection = factory.CreateConnection();
            return  connection.CreateModel();
        }
        public object ConsumerExchangeFanout()
        {
            var channel = Connection();

            var message = "";
            //创建消费者
            var consumer = new EventingBasicConsumer(channel);
            //注册接收事件，一旦创建连接就去拉取消息
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            //开始消费   注意因为是异步消费所以不会立马去 consumer.Received 这里面所以要用Console.ReadLine();
            channel.BasicConsume(queue: "FanoutExchangeceshi1",
                                 //和tcp协议的ack一样，为false则服务端必须在收到客户端的回执（ack）后才能删除本条消息
                                 autoAck: true,
                                 consumer: consumer);
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            return message;

        }
        public object ConsumerExchangeDirect()
        {
            var channel = Connection();

            var message = "";
            //创建消费者
            var consumer = new EventingBasicConsumer(channel);
            //注册接收事件，一旦创建连接就去拉取消息
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            //开始消费   注意因为是异步消费所以不会立马去 consumer.Received 这里面所以要用Console.ReadLine();
            channel.BasicConsume(queue: "DirectExchangeceshi1",
                                 //和tcp协议的ack一样，为false则服务端必须在收到客户端的回执（ack）后才能删除本条消息
                                 autoAck: true,
                                 consumer: consumer);
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            return message;
        }
        public object ConsumerExchangeTopic()
        {
            var channel = Connection();

            var message = "";
            //创建消费者
            var consumer = new EventingBasicConsumer(channel);
            //注册接收事件，一旦创建连接就去拉取消息
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            //开始消费   注意因为是异步消费所以不会立马去 consumer.Received 这里面所以要用Console.ReadLine();
            channel.BasicConsume(queue: "TopicExchangeceshi1",
                                 //和tcp协议的ack一样，为false则服务端必须在收到客户端的回执（ack）后才能删除本条消息
                                 autoAck: true,
                                 consumer: consumer);
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            return message;
        }
        public object ConsumerExchangeHeaders()
        {
            throw new NotImplementedException();
        }

    }
}
