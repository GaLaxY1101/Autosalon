using Autosalon.src;
using Autosalon.src.models;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Autosalon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());

            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");

            // создаем конфигурацию
            var config = builder.Build();

            // получаем строку подключения
            String connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AutosalonContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AutosalonContext context = new AutosalonContext(options))
            {
                var Clients = context.Clients.ToList();
                Console.WriteLine("Clients:");
                foreach (var client in Clients)
                {
                    Console.WriteLine("First name: " + client.FirstName +
                        "\nLast name: " + client.LastName +
                        "\nPhoneNumber: " + client.PhoneNumber +
                        "\nAge: " + client.Age +
                        "\n======================================"
                        );
                }

                //Створення об'єкту і занесення його в базу даних
                var client1 = new Client("Stasy", "Johnson", "+380995487329", 18, "785443674");

                context.Clients.Add(client1);
                context.SaveChanges();

                //Редагування об'єкту
                var clientToBeChanged = context.Clients.Where(c => c.Id == 4).FirstOrDefault();
                if (clientToBeChanged != null)
                {
                    clientToBeChanged.Age = 26;
                }
                context.SaveChanges();

                //Видалення об'єкту
                var clientToDelete = context.Clients.Where(c => c.FirstName == "Stasy").FirstOrDefault();
                context.Clients.Remove(clientToDelete);
                context.SaveChanges();
            }

            
        }
    }
}