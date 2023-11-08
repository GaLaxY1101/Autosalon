﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autosalon.src.models;
using autosalon_classes.src.Interfaces;

namespace Autosalon.src
{
    public class AutosalonContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        //public DbSet<Employee> Employees { get; set; } = null!;
        ////public DbSet<Operation> Operations { get; set; } = null!;

        //public DbSet<FuelTypes> fuelTypes { get; set; } = null!;

        public DbSet<Motor> Motors { get; set; } = null!;
        //public DbSet<ElectricEngine> ElectricEngines { get; set; } = null!;
        //public DbSet<Model> Models { get; set; } = null!;
        //public DbSet<Transmission> Transmissions { get; set; } = null!;

        //public DbSet<Auto> Autos = null!;

        public AutosalonContext()
        {

        }

        public AutosalonContext(DbContextOptions<AutosalonContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=WIN-K9Q7MMLHJIS\\SQLEXPRESS; Database=Autosalon; Integrated Security = true; TrustServerCertificate=true;\r\n");
            
        //}

    }
}