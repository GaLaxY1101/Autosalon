using Autosalon.src;
using Autosalon.src.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
                Client c1 = new Client("Max", "Zoe", "0509854388");
                context.Clients.Add(c1);
                context.SaveChanges();
            }
        }
    }
}