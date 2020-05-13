using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace serverChat
{
    public static class Server
    {
        public static List<Client> Clients = new List<Client>();
        public static void NewClient(Socket handle)  // создание нового пользовотеля
        {
            try
            {
                Client newClient = new Client(handle);
                Clients.Add(newClient);
                Console.WriteLine("Новый клиент подключен: {0}", handle.RemoteEndPoint);
            }
            catch (Exception exp) { Console.WriteLine("Ошибка с добавлением пользовотеля: {0}.",exp.Message); }
        }
        public static void EndClient(Client client)  // Выход пользовотеля
        {
            try
            {
                client.End();
                Clients.Remove(client);
                Console.WriteLine("Пользовотель {0} отключился.", client.UserName);
            }
            catch (Exception exp) { Console.WriteLine("Ошибка отключения: {0}.",exp.Message); }
        }
        public static void UpdateAllChats()  // Полное обновление кол пользовотелей
        {
            try
            {
                int countUsers = Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Clients[i].UpdateChat();
                }
            }
            catch (Exception exp) { Console.WriteLine("Ошибка обновления: {0}.",exp.Message); }
        }
        
    }
}
