using RabbitMQ.Client;
using System.Text;

namespace WebApplication1.Api
{
    public class ProducerS : ProducerSI
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
            return connection.CreateModel();
        }
        //发布订阅交换机
        public void ProducerExchangeFanout()
        {

            var channel = Connection();
            //创建队列
            channel.QueueDeclare(queue: "FanoutExchangeceshi1", durable: true, exclusive: false, autoDelete: false, arguments: null);
            
            channel.QueueDeclare(queue: "FanoutExchangeceshi2", durable: true, exclusive: false, autoDelete: false, arguments: null);

            //创建交换机
            channel.ExchangeDeclare(exchange: "FanoutExchange", type: ExchangeType.Fanout);

            //绑定交换机
            channel.QueueBind(queue: "FanoutExchangeceshi1", exchange: "FanoutExchange", routingKey: string.Empty);
            channel.QueueBind(queue: "FanoutExchangeceshi2", exchange: "FanoutExchange", routingKey: string.Empty);

            for (int i = 0; i < 10; i++)
            {

                //创建将要发布的信息
                var message = "FanoutExchange" + i;
                //转换为字节
                var body = Encoding.UTF8.GetBytes(message);
                //将信息发送到指定的交换机在发给队列 
                channel.BasicPublish(exchange: "FanoutExchange",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);

            }
        }
        //路由交换机
        public void ProducerExchangeDirect()
        {
            var channel = Connection();
            //创建队列
            channel.QueueDeclare(queue: "DirectExchangeceshi1", durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueDeclare(queue: "DirectExchangeceshi2", durable: true, exclusive: false, autoDelete: false, arguments: null);

            //创建交换机                 路由交换机改一下交换机类型
            channel.ExchangeDeclare(exchange: "DirectExchange", type: ExchangeType.Direct);

            //绑定交换机                    绑定交换机声明Key 在下面发送消息的时候根据key发送
            channel.QueueBind(queue: "DirectExchangeceshi1", exchange: "DirectExchange", routingKey: ".net");
            channel.QueueBind(queue: "DirectExchangeceshi2", exchange: "DirectExchange", routingKey: "java");

            for (int i = 0; i < 10; i++)
            {

                //创建将要发布的信息
                var message = "DirectExchange" + i;
                //转换为字节
                var body = Encoding.UTF8.GetBytes(message);
                //将信息发送到指定的交换机在发给队列    根据key发送 发送给.net的队列
                channel.BasicPublish(exchange: "DirectExchange",
                                     routingKey: ".net",
                                     basicProperties: null,
                                     body: body);

            }
        }
        //主题交换机
        public void ProducerExchangeTopic()
        {
            var channel = Connection();
            //创建队列
            channel.QueueDeclare(queue: "TopicExchangeceshi1", durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueDeclare(queue: "TopicExchangeceshi2", durable: true, exclusive: false, autoDelete: false, arguments: null);

            //创建交换机                      改成主题交换机就可以
            channel.ExchangeDeclare(exchange: "TopicExchange", type: ExchangeType.Topic);

            //绑定交换机                    #表示匹配后面所有 *表示匹配后面任何一位
            channel.QueueBind(queue: "TopicExchangeceshi1", exchange: "TopicExchange", routingKey: ".net.#");
            channel.QueueBind(queue: "TopicExchangeceshi2", exchange: "TopicExchange", routingKey: "java*");

            for (int i = 0; i < 10; i++)
            {

                //创建将要发布的信息
                var message = "TopicExchange" + i;
                //转换为字节
                var body = Encoding.UTF8.GetBytes(message);
                //将信息发送到指定的交换机在发给队列 
                channel.BasicPublish(exchange: "TopicExchange",
                                     routingKey: ".net.7",
                                     basicProperties: null,
                                     body: body);

            }
        }
        //头交换机
        public void ProducerExchangeHeaders()
        {
         
        }


    }
}
