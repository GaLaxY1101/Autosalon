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
using Autosalon.src.JoinModels;

namespace Autosalon.src
{
    public class AutosalonContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        
        public DbSet<Operation> Operations { get; set; } = null!;

        public DbSet<Motor> Motors { get; set; } = null!;
        public DbSet<ElectricEngine> ElectricEngines { get; set; } = null!;

        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Transmission> Transmissions { get; set; } = null!;

        public DbSet<Auto> Autos = null!;

        //Link entities
        public DbSet<ModelMotorLink> MotorLinks { get; set; }
        public DbSet<ModelElectricEngineLink> ElectricEngineLinks { get; set; } 

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
            modelBuilder.Entity<Model>(ModelConfigure);
            modelBuilder.Entity<ModelMotorLink>(ModelMotorLinkConfigure);
            modelBuilder.Entity<ModelElectricEngineLink>(ModelElectricEngineLinkConfigure);
            modelBuilder.Entity<ModelTransmissionLink>(ModelTransmissionLinkConfigure);
            modelBuilder.Entity<AutoMotorLink>(AutoMotorLinkConfigure);
            modelBuilder.Entity<AutoElectricEngineLink>(AutoElectricEngineLinkConfigure);
            modelBuilder.Entity<Auto>(AutoConfigure);
            modelBuilder.Entity<AutoEquipmentLink>(AutoEquipmentLinkConfigure);
        }

        //==================== Configure models ====================

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
                .HasForeignKey(e => e.EmployeeID);;

            builder
                .HasOne(o => o.Auto)
                .WithOne(a => a.Operation)
                .HasForeignKey<Auto>(a => a.OperationId);
        }

        //Configure ElectricEngine
        public void ElectricEngineConfigure(EntityTypeBuilder<ElectricEngine> builder)
        {
           
        }

        //Configure Model
        public void ModelConfigure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.id);

            
        }

        public void AutoConfigure(EntityTypeBuilder<Auto> builder) 
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(m => m.Model)
                .WithMany(a => a.Autos)
                .HasForeignKey(m => m.ModelID);

            builder
                .HasOne(a => a.Transmission)
                .WithMany(t => t.Autos)
                .HasForeignKey(a => a.TransmissionId);
   
        }
        // ============================================================

        //==================== Configure LinkModels ====================
        public void ModelMotorLinkConfigure(EntityTypeBuilder<ModelMotorLink> builder) 
        {
            builder
                .HasKey(fields => new { fields.MotorId, fields.ModelId });
            
            builder
                .HasOne(ml => ml.Model)
                .WithMany(m => m.MotorLinks)
                .HasForeignKey(ml => ml.ModelId);

            builder
                .HasOne(ml => ml.Motor)
                .WithMany(m => m.ModelMotorLinks)
                .HasForeignKey(ml => ml.MotorId);
              
        }

        public void ModelElectricEngineLinkConfigure(EntityTypeBuilder<ModelElectricEngineLink> builder)
        {
            builder.HasKey(m => new { m.ModelId, m.ElectricEngineId });

            builder
                .HasOne(ml => ml.Model)
                .WithMany(m => m.ElectricEngineLinks)
                .HasForeignKey(ml => ml.ModelId);

            builder
                 .HasOne(ml => ml.ElectricEngine)
                 .WithMany(m => m.ModelElectricEngineLinks)
                 .HasForeignKey(ml => ml.ElectricEngineId);
        }

        public void ModelTransmissionLinkConfigure(EntityTypeBuilder<ModelTransmissionLink> builder)
        {
            builder.HasKey (m => new { m.ModelId, m.TransmissionId });

            builder
                .HasOne(ml => ml.Model)
                .WithMany(m => m.ModelTransmissionLinks)
                .HasForeignKey (ml => ml.ModelId);

            builder
                .HasOne (ml => ml.Transmission)
                .WithMany(m => m.ModelTransmissionLinks)
                .HasForeignKey(ml => ml.ModelId);
        }

        public void AutoEquipmentLinkConfigure(EntityTypeBuilder<AutoEquipmentLink> builder) 
        { 
            builder.HasKey(a => new {a.AutoId, a.EquipmentId});

            builder
                .HasOne(al => al.Auto)
                .WithMany(a => a.AutoEquipmentLink)
                .HasForeignKey(al => al.AutoId);

            builder
                .HasOne(al => al.Equipment)
                .WithMany(a => a.AutoEquipmentLink)
                .HasForeignKey(al => al.EquipmentId);
        }

        public void AutoMotorLinkConfigure(EntityTypeBuilder<AutoMotorLink> builder) 
        {
            builder
            .HasKey(aml => new { aml.AutoId, aml.MotorId });

            builder
                .HasOne(aml => aml.Auto)
                .WithMany(a => a.AutoMotorLink)
                .HasForeignKey(aml => aml.AutoId);

            builder
                .HasOne(aml => aml.Motor)
                .WithMany(m => m.AutoMotorLinks)
                .HasForeignKey(aml => aml.MotorId);
        }


        public void AutoElectricEngineLinkConfigure(EntityTypeBuilder<AutoElectricEngineLink> builder)
        {
            builder
            .HasKey(aml => new { aml.AutoId, aml.ElectricEngineId });

            builder
                .HasOne(aml => aml.Auto)
                .WithMany(a => a.AutoElectricEngineLink)
                .HasForeignKey(aml => aml.AutoId);

            builder
                .HasOne(aml => aml.ElectricEngine)
                .WithMany(m => m.AutoElectricEngineLink)
                .HasForeignKey(aml => aml.ElectricEngineId);
        }
        //============================================================
    }
}
