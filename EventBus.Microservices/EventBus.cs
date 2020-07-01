using RabbitMQ.Client;
using System;
using System.Text;

namespace EventBus.Microservices
{
    public static class EventBus
    {
        static ConnectionFactory factory;
        static IConnection connection;
        static IModel channel;
        static EventBus()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "MicroServicesTestExchange", type: "topic");

            channel.QueueDeclare(queue: "ProductQueue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            channel.QueueBind(queue: "ProductQueue",
                            exchange: "MicroServicesTestExchange",
                            routingKey: "*.Product.*");

            channel.QueueDeclare(queue: "CustomerQueue",
                                   durable: false,
                                   exclusive: false,
                                   autoDelete: false,
                                   arguments: null);
            channel.QueueBind(queue: "CustomerQueue",
                            exchange: "MicroServicesTestExchange",
                            routingKey: "Customer.#");

        }

        public static  void Send(string routingKey, byte[] message, string exchange="")
        {
            try
            {
                channel.BasicPublish(exchange: "MicroServicesTestExchange",
                                    routingKey: routingKey,
                                    basicProperties: null,
                                    body: message);
            }
            catch(Exception ep)
            {

            }
        }


        public static void Receive(IModel channel)
        {

        }

    }
}
