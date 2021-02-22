using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace TestadorAzureServiceBus.Fila.Sender
{
    public static class Program
    {
        // Connection String for the namespace can be obtained from the Azure portal under the 
        // 'Shared Access policies' section.

        //This should be stored on your Vault, appSettings or whatever ofc
        private const string ServiceBusConnectionString = "YourConnectionStringHere";
        private const string QueueName = "YourQueueNameHere";
        private static IQueueClient _queueClient;

        public static async Task Main(string[] args)
        {
            const int numberOfMessages = 10;
            _queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            _queueClient.ServiceBusConnection.TransportType = TransportType.AmqpWebSockets;

            Console.WriteLine("Sending messages...");

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            Console.WriteLine("Press ENTER key to exit.");
            Console.ReadKey();

            await _queueClient.CloseAsync();
        }

        private static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the queue, this could be an serializable json object for example
                    var messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the queue
                    await _queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
