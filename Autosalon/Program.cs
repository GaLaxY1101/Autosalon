using Autosalon.src;
using Autosalon.src.models;
using Azure;
using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.CodeDom.Compiler;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace Autosalon
{
    internal class Program
    {
        public static Mutex? mutex { get; set; } = new Mutex();

        public static Semaphore sem { get; set; } = new Semaphore(1, 2);
        
        static void Main(string[] args)
        {
            ContextFactory cf = new ContextFactory();

            var context = cf.CreateDbContext(new[] { "DefaultConnection" });

            //// Example of using monitor 
            //Thread myThread = new(GenerateClientsThread1);
            //Thread myThread2 = new(GenerateClientsThread2);

            //myThread.Start(context);
            //myThread2.Start(context);

            //// Example of using mutex

            //Thread myThread3 = new(GenerateClientsThread3);
            //Thread myThread4 = new(GenerateClientsThread4);

            //myThread3.Start(context);
            //myThread4.Start(context);

            // Semaphore
            //Thread myThread5 = new Thread(GenerateClientsThread5);
            
            ////Read data (monitor)
            //for (int i = 0; i < 4; i++) 
            //{
            //    Thread t1 = new(PrintClientsMonitor);
            //    t1.Name = $"Thread {i}";
            //    t1.Start(context);
            //}

            //Read data (task)


            var outer = Task.Factory.StartNew(() =>      // зовнішнє завдання
            {
                Console.WriteLine("Outer task starting...");
                foreach(Client c in context.Clients.ToList()) Console.WriteLine($"Task {Task.CurrentId}: {c.FirstName} {c.LastName}");

                Console.WriteLine($"Task {Task.CurrentId}: {context.Clients.First().FirstName} {context.Clients.First().LastName}");
                var inner = Task.Factory.StartNew(() =>  // вкладене завдання
                {
                    Console.WriteLine($"Inner task({Task.CurrentId}) starting...");
                    Thread.Sleep(2000);
                    foreach (Client c in context.Clients.ToList()) Console.WriteLine($"Task {Task.CurrentId}: {c.FirstName} {c.LastName}");
                    Console.WriteLine("Inner task finished.");
                }, TaskCreationOptions.AttachedToParent);
            });
            outer.Wait();
            Console.WriteLine("End of Main");
        }


        public static void GenerateClientsThread1(object? contextArg)
        {
            if (contextArg is AutosalonContext context)
            {
                bool acquiredLock = false;
                try
                {
                    Monitor.Enter(context, ref acquiredLock);
                    context.Clients.Add(new Client { FirstName = "Serhii", LastName = "Shevchenko", Age = 35, PassportNumber = "92321", PhoneNumber = "0507799438" });
                    Console.WriteLine("Thread1: First client added");
                    context.Clients.Add(new Client { FirstName = "Illia", LastName = "Pop", Age = 20, PassportNumber = "92133", PhoneNumber = "0508599438" });
                    Console.WriteLine("Thread1: The second client added");
                    context.SaveChanges();
                }
                finally
                {
                    if (acquiredLock) Monitor.Exit(context);
                }
            }
        }
        public static void GenerateClientsThread2(object? contextArg)
            {

                if (contextArg is AutosalonContext context)
                {
                    bool acquiredLock = false;
                    try
                    {
                        Monitor.Enter(context, ref acquiredLock);
                        context.Clients.Add(new Client { FirstName = "Lucy", LastName = "Rock", Age = 22, PassportNumber = "92121", PhoneNumber = "0508399433" });
                        Console.WriteLine("Thread2: First client added");
                        context.Clients.Add(new Client { FirstName = "Olia", LastName = "Blackwood", Age = 22, PassportNumber = "92311", PhoneNumber = "0507799431" });
                        Console.WriteLine("Thread2: The second client added");
                        context.SaveChanges();
                    }
                    finally
                    {
                        if (acquiredLock) Monitor.Exit(context);
                    }
                }
            }
        public static void GenerateClientsThread3(object? contextArg)
        {
            if (contextArg is AutosalonContext context)
            {
                mutex.WaitOne();
                context.Clients.Add(new Client { FirstName = "Nadia", LastName = "Koval", Age = 33, PassportNumber = "82321", PhoneNumber = "0507799455" });
                Console.WriteLine("Thread3: First client added");
                context.Clients.Add(new Client { FirstName = "Carlo", LastName = "Ball", Age = 66, PassportNumber = "92223", PhoneNumber = "0502199438" });
                Console.WriteLine("Thread3: The second client added");
                context.SaveChanges();

                mutex.ReleaseMutex();
            }
        }

        public static void GenerateClientsThread4(object? contextArg)
        {
            if (contextArg is AutosalonContext context)
            {
                mutex.WaitOne();

                context.Clients.Add(new Client { FirstName = "Bob", LastName = "Carrol", Age = 41, PassportNumber = "22321", PhoneNumber = "0507819455" });
                Console.WriteLine("Thread4: First client added");
                context.Clients.Add(new Client { FirstName = "Luc", LastName = "Sky", Age = 25, PassportNumber = "92123", PhoneNumber = "0503299438" });
                Console.WriteLine("Thread4: The second client added");
                context.SaveChanges();

                mutex.ReleaseMutex();
            }
        }

        public static void GenerateClientsThread5(object? contextArg)
        {
            if (contextArg is AutosalonContext context)
            {
                sem.WaitOne();

                context.Clients.Add(new Client { FirstName = "Bob", LastName = "Carrol", Age = 41, PassportNumber = "22321", PhoneNumber = "0507819455" });
                Console.WriteLine("Thread4: First client added");
                context.Clients.Add(new Client { FirstName = "Luc", LastName = "Sky", Age = 25, PassportNumber = "92123", PhoneNumber = "0503299438" });
                Console.WriteLine("Thread4: The second client added");
                context.SaveChanges();

                sem.Release();
            }
        }

        public static void PrintClientsMonitor(object?  contextArg)
        {
            if (contextArg is AutosalonContext context)
            {
                bool acquiredLock = false;
                try
                {
                    Monitor.Enter(context,ref  acquiredLock);
                    foreach (Client c in context.Clients.ToList()) Console.WriteLine($"{Thread.CurrentThread.Name} : {c.FirstName} {c.LastName}");

                }
                finally
                {
                    if (acquiredLock) Monitor.Exit(context);
                }
            }
        }

        public static void PrintClientsMutex()
            {
                Mutex mutexObj = new();

                mutexObj.WaitOne();     // Зупиняємо потік до отримання мьютексу

                ContextFactory cf = new ContextFactory();
                using (var context = cf.CreateDbContext(new[] { "DefaultConnection" }))
                {
                    foreach (Client client in context.Clients.ToList())
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {client.FirstName} {client.LastName}");
                        //Thread.Sleep(100);
                    }
                }
                mutexObj.ReleaseMutex();    // звільняємо м'ютекс
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


            context.Database.ExecuteSqlRaw("EXEC GetClientNameById @id, @name OUT", idParam, nameParam);
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