﻿// <auto-generated />
using System;
using Autosalon.src;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autosalon.Migrations
{
    [DbContext(typeof(AutosalonContext))]
    [Migration("20231207131234_AddEmployees")]
    partial class AddEmployees
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Autosalon.src.JoinModels.AutoElectricEngineLink", b =>
                {
                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("ElectricEngineId")
                        .HasColumnType("int");

                    b.HasKey("AutoId", "ElectricEngineId");

                    b.HasIndex("ElectricEngineId");

                    b.ToTable("AutoElectricEngineLink");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.AutoEquipmentLink", b =>
                {
                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("AutoId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("AutoEquipmentLink");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.AutoMotorLink", b =>
                {
                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("MotorId")
                        .HasColumnType("int");

                    b.HasKey("AutoId", "MotorId");

                    b.HasIndex("MotorId");

                    b.ToTable("AutoMotorLink");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.ModelElectricEngineLink", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("ElectricEngineId")
                        .HasColumnType("int");

                    b.HasKey("ModelId", "ElectricEngineId");

                    b.HasIndex("ElectricEngineId");

                    b.ToTable("ElectricEngineLinks");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.ModelMotorLink", b =>
                {
                    b.Property<int>("MotorId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("MotorId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("MotorLinks");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.ModelTransmissionLink", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int");

                    b.HasKey("ModelId", "TransmissionId");

                    b.ToTable("ModelTransmissionLink");
                });

            modelBuilder.Entity("Autosalon.src.models.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Colour")
                        .HasColumnType("int");

                    b.Property<int>("Mass")
                        .HasColumnType("int");

                    b.Property<int>("Milage")
                        .HasColumnType("int");

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelID");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.HasIndex("TransmissionId");

                    b.ToTable("Auto");
                });

            modelBuilder.Entity("Autosalon.src.models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Id_PassportName");

                    b.ToTable("Clients", t =>
                        {
                            t.HasCheckConstraint("Age", "Age > 17")
                                .HasName("CheckForAge");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 21,
                            FirstName = "Max",
                            LastName = "Stuart",
                            PassportNumber = "246898432",
                            PhoneNumber = "+380994873755"
                        },
                        new
                        {
                            Id = 2,
                            Age = 25,
                            FirstName = "Alice",
                            LastName = "Jones",
                            PassportNumber = "250953999",
                            PhoneNumber = "+380509843865"
                        },
                        new
                        {
                            Id = 3,
                            Age = 40,
                            FirstName = "Tom",
                            LastName = "Ford",
                            PassportNumber = "895487342",
                            PhoneNumber = "+380504390234"
                        },
                        new
                        {
                            Id = 4,
                            Age = 33,
                            FirstName = "Hanry",
                            LastName = "Davis",
                            PassportNumber = "987437677",
                            PhoneNumber = "+380669543866"
                        },
                        new
                        {
                            Id = 5,
                            Age = 55,
                            FirstName = "Alex",
                            LastName = "Moshi",
                            PassportNumber = "987444677",
                            PhoneNumber = "+380559543866"
                        },
                        new
                        {
                            Id = 6,
                            Age = 21,
                            FirstName = "Mrritz",
                            LastName = "Luckk",
                            PassportNumber = "9812317677",
                            PhoneNumber = "+380665584093"
                        },
                        new
                        {
                            Id = 7,
                            Age = 20,
                            FirstName = "John",
                            LastName = "Moore",
                            PassportNumber = "9498843233",
                            PhoneNumber = "+380669533212"
                        },
                        new
                        {
                            Id = 8,
                            Age = 18,
                            FirstName = "Xenia",
                            LastName = "Amoore",
                            PassportNumber = "977737677",
                            PhoneNumber = "+380669543822"
                        });
                });

            modelBuilder.Entity("Autosalon.src.models.ElectricEngine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Torque")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ElectricEngines");
                });

            modelBuilder.Entity("Autosalon.src.models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Alina",
                            LastName = "Niechkina",
                            PhoneNumber = "0508529088",
                            Position = 0
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Luck",
                            LastName = "Skywalker",
                            PhoneNumber = "0995098432",
                            Position = 2
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Lucy",
                            LastName = "Johnson",
                            PhoneNumber = "0669854398",
                            Position = 5
                        });
                });

            modelBuilder.Entity("Autosalon.src.models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Autosalon.src.models.Model", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("BodyType")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelDrive")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Autosalon.src.models.Motor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<float>("MotorVolume")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Torque")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasAlternateKey("id", "Title")
                        .HasName("UniqueMotorTitle");

                    b.ToTable("Motors");
                });

            modelBuilder.Entity("Autosalon.src.models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfOperation")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Autosalon.src.models.Transmission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("SpeedCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Not set");

                    b.Property<int>("TransmissionType")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Transmissions");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.AutoElectricEngineLink", b =>
                {
                    b.HasOne("Autosalon.src.models.Auto", "Auto")
                        .WithMany("AutoElectricEngineLink")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.ElectricEngine", "ElectricEngine")
                        .WithMany("AutoElectricEngineLink")
                        .HasForeignKey("ElectricEngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("ElectricEngine");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.AutoEquipmentLink", b =>
                {
                    b.HasOne("Autosalon.src.models.Auto", "Auto")
                        .WithMany("AutoEquipmentLink")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Equipment", "Equipment")
                        .WithMany("AutoEquipmentLink")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.AutoMotorLink", b =>
                {
                    b.HasOne("Autosalon.src.models.Auto", "Auto")
                        .WithMany("AutoMotorLink")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Motor", "Motor")
                        .WithMany("AutoMotorLinks")
                        .HasForeignKey("MotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Motor");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.ModelElectricEngineLink", b =>
                {
                    b.HasOne("Autosalon.src.models.ElectricEngine", "ElectricEngine")
                        .WithMany("ModelElectricEngineLinks")
                        .HasForeignKey("ElectricEngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Model", "Model")
                        .WithMany("ElectricEngineLinks")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectricEngine");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.ModelMotorLink", b =>
                {
                    b.HasOne("Autosalon.src.models.Model", "Model")
                        .WithMany("MotorLinks")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Motor", "Motor")
                        .WithMany("ModelMotorLinks")
                        .HasForeignKey("MotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Motor");
                });

            modelBuilder.Entity("Autosalon.src.JoinModels.ModelTransmissionLink", b =>
                {
                    b.HasOne("Autosalon.src.models.Model", "Model")
                        .WithMany("ModelTransmissionLinks")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Transmission", "Transmission")
                        .WithMany("ModelTransmissionLinks")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("Autosalon.src.models.Auto", b =>
                {
                    b.HasOne("Autosalon.src.models.Model", "Model")
                        .WithMany("Autos")
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Operation", "Operation")
                        .WithOne("Auto")
                        .HasForeignKey("Autosalon.src.models.Auto", "OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Transmission", "Transmission")
                        .WithMany("Autos")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Operation");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("Autosalon.src.models.Operation", b =>
                {
                    b.HasOne("Autosalon.src.models.Client", "Client")
                        .WithMany("Operations")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autosalon.src.models.Employee", "Employee")
                        .WithMany("Operations")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Autosalon.src.models.Auto", b =>
                {
                    b.Navigation("AutoElectricEngineLink");

                    b.Navigation("AutoEquipmentLink");

                    b.Navigation("AutoMotorLink");
                });

            modelBuilder.Entity("Autosalon.src.models.Client", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("Autosalon.src.models.ElectricEngine", b =>
                {
                    b.Navigation("AutoElectricEngineLink");

                    b.Navigation("ModelElectricEngineLinks");
                });

            modelBuilder.Entity("Autosalon.src.models.Employee", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("Autosalon.src.models.Equipment", b =>
                {
                    b.Navigation("AutoEquipmentLink");
                });

            modelBuilder.Entity("Autosalon.src.models.Model", b =>
                {
                    b.Navigation("Autos");

                    b.Navigation("ElectricEngineLinks");

                    b.Navigation("ModelTransmissionLinks");

                    b.Navigation("MotorLinks");
                });

            modelBuilder.Entity("Autosalon.src.models.Motor", b =>
                {
                    b.Navigation("AutoMotorLinks");

                    b.Navigation("ModelMotorLinks");
                });

            modelBuilder.Entity("Autosalon.src.models.Operation", b =>
                {
                    b.Navigation("Auto");
                });

            modelBuilder.Entity("Autosalon.src.models.Transmission", b =>
                {
                    b.Navigation("Autos");

                    b.Navigation("ModelTransmissionLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
