using Autosalon.src;
using Autosalon.src.models;
using Azure;
using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Text.RegularExpressions;

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
                //context.Operations.Add(new Operation { DateOfOperation = DateTime.Now, ClientID = 1, EmployeeID = 1, Amount = 1, Status = OperationStatuses.Completed });
                //context.Operations.Add(new Operation { DateOfOperation = DateTime.Now, ClientID = 2, EmployeeID = 1, Amount = 1, Status = OperationStatuses.Completed });
                //context.Operations.Add(new Operation { DateOfOperation = DateTime.Now, ClientID = 2, EmployeeID = 2, Amount = 1, Status = OperationStatuses.Completed });
                //context.Operations.Add(new Operation { DateOfOperation = DateTime.Now, ClientID = 3, EmployeeID = 3, Amount = 1, Status = OperationStatuses.Completed });
                //context.Operations.Add(new Operation { DateOfOperation = DateTime.Now, ClientID = 4, EmployeeID = 1, Amount = 1, Status = OperationStatuses.NotPaid });
                //context.Operations.Add(new Operation { DateOfOperation = DateTime.Now, ClientID =5, EmployeeID = 1, Amount = 1, Status = OperationStatuses.Pending });



                //var Clients = context.Clients.ToList();
                //Console.WriteLine("Clients:");
                //foreach (var client in Clients)
                //{
                //    Console.WriteLine("First name: " + client.FirstName +
                //        "\nLast name: " + client.LastName +
                //        "\nPhoneNumber: " + client.PhoneNumber +
                //        "\nAge: " + client.Age +
                //        "\n======================================"
                //        );
                //}




            }


        }


        public static void IntersectExample(AutosalonContext context)
        {
            var cls = context.Clients.Where(a => a.Age > 25).Intersect(context.Clients.Where(b => b.PassportNumber.StartsWith("9")));

            var Clients = context.Clients.ToList();
            

        }
        
        public static void UnionExample(AutosalonContext context)
        {
            var cls = context.Clients.Where(a => a.Age > 25).Union(context.Clients.Where(b => b.PassportNumber.StartsWith("9")));
            PrintClients(cls.ToList());
        }

        public static void ExceptExample(AutosalonContext context)
        {
            var cls = context.Clients.Where(a => a.PhoneNumber.StartsWith("+38066")).Except(context.Clients.Where(b => b.Age > 23));
            PrintClients(cls.ToList());
        }

        public static void JoinExample(AutosalonContext context)
        {
            var view = context.Operations.Join(context.Employees,
                    o => o.EmployeeID,
                    e => e.Id,
                    (o, e) => new
                    {
                        OperationId = o.Id,
                        EmployeeName = e.FirstName,
                        EmployeeLastName = e.LastName,
                    });

            foreach (var v in view)
            {
                Console.WriteLine($"Operation: {v.OperationId} \nEmployee: {v.EmployeeName} {v.EmployeeLastName}. \n");
            }
        }

        public static void DistinctExample(AutosalonContext context)
        {
            var dist = context.Operations.Select(o => o.Status).Distinct().ToList();

            foreach (var v in dist) Console.WriteLine(v.ToString());
        }

        public static void AsyncExample(AutosalonContext context)
        {

        }

        public static void GroupByAndAggregateFunctionsEcample(AutosalonContext context)
        {
                var ls = context.Operations
                    .GroupBy(o => o.EmployeeID)
                    .Select(s => new { Key = s.Key, Count = s.Count() });


            foreach (var v in ls) Console.WriteLine($"Key: {v.Key} \n Count: {v.Count} \n");

            int maxId = context.Employees.Max(u => u.Id);
            int minId = context.Employees.Min(u => u.Id);

            Console.WriteLine(maxId);
            Console.WriteLine(minId);
        }

        public static void EagerLoadingExample(AutosalonContext context) 
        {
            var emoployeeOperation = context.Operations.Include(e => e.Employee).ToList();
            foreach (var e in emoployeeOperation) Console.WriteLine($"Operation id:{e.Id} \nEmployee: {((Employee)e.Employee).FirstName} {((Employee)e.Employee).LastName} \n");
        }

        public static void ExplicitLoadingExample(AutosalonContext context) 
        {
            var employeeExplicitLoad = context.Employees.FirstOrDefault();
            context.Operations.Where(o => o.EmployeeID == employeeExplicitLoad.Id).Load();

            Console.WriteLine($"Employee: {employeeExplicitLoad.FirstName} {employeeExplicitLoad.LastName}");
            Console.WriteLine("Operations:\n");
            foreach (var e in employeeExplicitLoad.Operations) Console.WriteLine($"{e.Id} : {e.Status}");
        }

        public static void LazyLoadingExample(AutosalonContext context)
        {
            var operations = context.Operations.ToList();
            Console.WriteLine(operations.FirstOrDefault().Employee.Position);
        }

        public static void InvoleSavedFunction(AutosalonContext context)
        {
            //SqlParameter param = new SqlParameter("@age", 30);
            //var users = context.Clients.FromSqlRaw("SELECT * FROM GetClientByAge (@age)", param).ToList();
            //foreach (var u in users)
            //    Console.WriteLine($"{u.FirstName} - {u.Age}");

            //==================================OR======================================

            var clients = context.GetClientByAge(30);
            foreach (var u in clients)
                Console.WriteLine($"{u.FirstName} - {u.Age}");

        }

        public static void InvolveSavedProcedure(AutosalonContext context)
        {
            SqlParameter nameParam = new()
            {
                ParameterName = "@name",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 50,
            };

            SqlParameter idParam = new()
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.Int
            };

            idParam.Value = 2;


            context.Database.ExecuteSqlRaw("EXEC GetClientNameById @id, @name OUT", idParam,nameParam);
            Console.WriteLine(nameParam.Value);
        }

        public static void PrintClients(List<Client> list)
        {
            Console.WriteLine("Clients:");
            foreach (var client in list)
            {
                Console.WriteLine("First name: " + client.FirstName +
                    "\nLast name: " + client.LastName +
                    "\nPhoneNumber: " + client.PhoneNumber +
                    "\nAge: " + client.Age +
                    "\nPassport: " + client.PassportNumber +
                    "\n======================================"
                    );
            }
        }

        public static void NoTracking(AutosalonContext context)
        {
            var client = context.Clients.AsNoTracking().FirstOrDefault();


            Console.WriteLine(client.FirstName + " " + client.LastName);

            client.FirstName = "Oleg";
            client.LastName = "Sunny";

            context.SaveChanges();

            Console.WriteLine(context.Clients.FirstOrDefault().FirstName + " " + context.Clients.FirstOrDefault().LastName);
        }
    }
}