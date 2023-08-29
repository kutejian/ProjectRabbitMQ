using RabbitMQ.Client;

namespace WebApplication1.Api
{
    public interface ProducerSI
    {
        //连接配置 
        IModel Connection();
        //发布者 发布订阅交换机
        void ProducerExchangeFanout();
        //发布者 路由交换机
        void ProducerExchangeDirect();
        //发布者 主题交换机
        void ProducerExchangeTopic();
        //发布者 头交换机
        void ProducerExchangeHeaders();
    }
}
