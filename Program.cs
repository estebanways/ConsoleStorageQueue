using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace ConsoleStorageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "";

            QueueClient queue = new QueueClient(connectionString, "queuedemo");

            //for (int i = 1; i <= 3; i++)
            //{
            //      InsertMessage(queue,"Mensaje " +  i.ToString());
            //}
            RecibirMensajes(queue);
            //Console.WriteLine("Mensajes entregados");
            //Console.ReadLine();
        }

        private static void InsertMessage(QueueClient queue, string Message)
        {
            queue.SendMessage(Message);
        }

        private static void RecibirMensajes(QueueClient queue)
        {
            QueueProperties properties = queue.GetProperties();

            if (properties.ApproximateMessagesCount > 0)
            {
                QueueMessage[] retrieveMessage = queue.ReceiveMessages(1);
                string mensaje = retrieveMessage[0].Body.ToString();
                Console.WriteLine(mensaje);
                queue.DeleteMessage(retrieveMessage[0].MessageId, retrieveMessage[0].PopReceipt);
            }
        }
    }
}
