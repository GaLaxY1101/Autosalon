using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autosalon.src.models;
using autosalon_classes.src.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Autosalon.src
{
    public class AutosalonContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        
        public DbSet<Operation> Operations { get; set; } = null!;

        public DbSet<Motor> Motors { get; set; } = null!;
        public DbSet<ElectricEngine> ElectricEngines { get; set; } = null!;

        //public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Transmission> Transmissions { get; set; } = null!;

        //public DbSet<Auto> Autos = null!;

        public AutosalonContext()
        {

        }

        public AutosalonContext(DbContextOptions<AutosalonContext> options)
            : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        //fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>(ClientConfigure);
            modelBuilder.Entity<Motor>(MotorConfigure);
            modelBuilder.Entity<Transmission>(TransmissionConfigure);
            modelBuilder.Entity<Employee>(EmployeeConfigure);
            modelBuilder.Entity<Operation>(OperationConfigure);
            modelBuilder.Entity<ElectricEngine>(ElectricEngineConfigure);
            modelBuilder.Entity<Option>(OptionConfigure);
        }

        //Configure client 
        public void ClientConfigure(EntityTypeBuilder<Client> builder)
        {
            //builder.HasKey(u => new { u.Id, u.PassportNumber }).HasName("PK_Id_PassportName"); //складений первинний ключ
            builder.HasKey(u => u.Id).HasName("PK_Id_PassportName"); 
            builder.ToTable(u => u.HasCheckConstraint("Age", "Age > 17").HasName("CheckForAge")); // обмеження Check 
        }

        //Configure motor
        public void MotorConfigure(EntityTypeBuilder<Motor> builder)
        {
            builder.HasAlternateKey(u => new { u.id, u.Title }).HasName("UniqueMotorTitle"); // складений альтернативний ключ
        }

        //Configure transmission
        public void TransmissionConfigure(EntityTypeBuilder<Transmission> builder)
        {
            builder.HasKey(u => u.id); // первинний ключ
            builder.Property(u => u.SpeedCount).HasDefaultValue(5); // за замовчуванням
            builder.Property(u => u.Title).HasDefaultValue("Not set");
        }

        //Configure Employee
        public void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(b => b.FirstName).HasMaxLength(100); // Максимальна довжина рядка в базі - 100 символів

        }

        //Configure Operation
        public void OperationConfigure(EntityTypeBuilder<Operation> builder)
        {
            // One client have many operations
            // One operation have only one client
            builder
                .HasOne(c => c.Client)
                .WithMany(o => o.Operations)
                .HasForeignKey(c => c.ClientID);

            //One employee have many operations
            //One operation have only one employee
            builder
                .HasOne(e => (Employee)e.Employee!)
                .WithMany(o => o.Operations)
                .HasForeignKey(e => e.EmployeeID);
        }

        //Configure ElectricEngine
        public void ElectricEngineConfigure(EntityTypeBuilder<ElectricEngine> builder)
        {
           
        }

        public void OptionConfigure(EntityTypeBuilder<Option> builder)
        {

        }

        //Configure Model
        //public void ModelConfigure(EntityTypeBuilder<Model> builder)
        //{

        //}

    }
}
