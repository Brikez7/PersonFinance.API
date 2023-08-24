﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonFinance.API.DAL;
using PersonFinance.API.Domain.Entities.structs;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    [DbContext(typeof(PersonFinanceContext))]
    [Migration("20230824153138_initial_create")]
    partial class initial_create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal");

                    b.Property<ValueTuple<decimal, Currency>>("MoneyCredit")
                        .HasColumnType("record");

                    b.Property<string>("Person")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<DateTimeOffset>("ReceiptDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Returned")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ReturnedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<ValueTuple<decimal, Currency>?>("ReturnedMoney")
                        .HasColumnType("record");

                    b.Property<short>("TypeContract")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("contracts", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<DateTimeOffset>("ExpenditureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<ValueTuple<decimal, Currency>>("MoneySpent")
                        .HasColumnType("record");

                    b.Property<string>("PurposeSpending")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.ToTable("expenses", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Finance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<ValueTuple<decimal, Currency>>("Money")
                        .HasColumnType("record");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("finances", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Income", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<ValueTuple<decimal, Currency>>("MoneyReceived")
                        .HasColumnType("record");

                    b.Property<DateTimeOffset>("ReceiptDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TypeActivity")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.ToTable("incomes", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.MoneyAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<Guid>("Number")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SavingsId")
                        .HasColumnType("uuid");

                    b.Property<short>("TypeAccount")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("SavingsId");

                    b.ToTable("money_accounts", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Savings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.ToTable("savings_persons", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Finance", b =>
                {
                    b.HasOne("PersonFinance.API.Domain.Entities.MoneyAccount", "MoneyAccount")
                        .WithMany("Finances")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonFinance.API.Domain.Entities.Savings", "Savings")
                        .WithMany("Finances")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MoneyAccount");

                    b.Navigation("Savings");
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.MoneyAccount", b =>
                {
                    b.HasOne("PersonFinance.API.Domain.Entities.Savings", null)
                        .WithMany("MoneyAccounts")
                        .HasForeignKey("SavingsId");
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.MoneyAccount", b =>
                {
                    b.Navigation("Finances");
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Savings", b =>
                {
                    b.Navigation("Finances");

                    b.Navigation("MoneyAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
