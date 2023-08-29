using RabbitMQ.Client;

namespace WebApplication1.Api
{
    public interface ConsumerSI
    {
        //连接配置 
        IModel Connection();
        //发布者 发布订阅交换机
        object ConsumerExchangeFanout();
        //发布者 路由交换机
        object ConsumerExchangeDirect();
        //发布者 主题交换机
        object ConsumerExchangeTopic();
        //发布者 头交换机
        object ConsumerExchangeHeaders();
    }
}
