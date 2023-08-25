﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonFinance.API.DAL;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    [DbContext(typeof(PersonFinanceContext))]
    [Migration("20230825104756_money_change_one_link_to_2link_savings_money_account")]
    partial class money_change_one_link_to_2link_savings_money_account
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
                        .HasColumnType("numeric");

                    b.Property<string>("Person")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<DateTimeOffset>("ReceiptDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Returned")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ReturnedDate")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<Guid?>("MoneyAccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SavingsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MoneyAccountId");

                    b.HasIndex("SavingsId");

                    b.ToTable("finances", (string)null);
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Income", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

                    b.Property<Guid>("NumberBank")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SavingsId")
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

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Contract", b =>
                {
                    b.OwnsOne("PersonFinance.API.Domain.Entities.structs.Money", "MoneyCredit", b1 =>
                        {
                            b1.Property<Guid>("ContractId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<short>("Corrency")
                                .HasColumnType("smallint");

                            b1.HasKey("ContractId");

                            b1.ToTable("contracts");

                            b1.WithOwner()
                                .HasForeignKey("ContractId");
                        });

                    b.OwnsOne("PersonFinance.API.Domain.Entities.structs.Money", "ReturnedMoney", b1 =>
                        {
                            b1.Property<Guid>("ContractId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<short>("Corrency")
                                .HasColumnType("smallint");

                            b1.HasKey("ContractId");

                            b1.ToTable("contracts");

                            b1.WithOwner()
                                .HasForeignKey("ContractId");
                        });

                    b.Navigation("MoneyCredit")
                        .IsRequired();

                    b.Navigation("ReturnedMoney");
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Expense", b =>
                {
                    b.OwnsOne("PersonFinance.API.Domain.Entities.structs.Money", "MoneySpent", b1 =>
                        {
                            b1.Property<Guid>("ExpenseId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<short>("Corrency")
                                .HasColumnType("smallint");

                            b1.HasKey("ExpenseId");

                            b1.ToTable("expenses");

                            b1.WithOwner()
                                .HasForeignKey("ExpenseId");
                        });

                    b.Navigation("MoneySpent")
                        .IsRequired();
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Finance", b =>
                {
                    b.HasOne("PersonFinance.API.Domain.Entities.MoneyAccount", "MoneyAccount")
                        .WithMany("Finances")
                        .HasForeignKey("MoneyAccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PersonFinance.API.Domain.Entities.Savings", "Savings")
                        .WithMany("Finances")
                        .HasForeignKey("SavingsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("PersonFinance.API.Domain.Entities.structs.Money", "Money", b1 =>
                        {
                            b1.Property<Guid>("FinanceId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<short>("Corrency")
                                .HasColumnType("smallint");

                            b1.HasKey("FinanceId");

                            b1.ToTable("finances");

                            b1.WithOwner()
                                .HasForeignKey("FinanceId");
                        });

                    b.Navigation("Money")
                        .IsRequired();

                    b.Navigation("MoneyAccount");

                    b.Navigation("Savings");
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.Income", b =>
                {
                    b.OwnsOne("PersonFinance.API.Domain.Entities.structs.Money", "MoneyReceived", b1 =>
                        {
                            b1.Property<Guid>("IncomeId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<short>("Corrency")
                                .HasColumnType("smallint");

                            b1.HasKey("IncomeId");

                            b1.ToTable("incomes");

                            b1.WithOwner()
                                .HasForeignKey("IncomeId");
                        });

                    b.Navigation("MoneyReceived")
                        .IsRequired();
                });

            modelBuilder.Entity("PersonFinance.API.Domain.Entities.MoneyAccount", b =>
                {
                    b.HasOne("PersonFinance.API.Domain.Entities.Savings", "Savings")
                        .WithMany("MoneyAccounts")
                        .HasForeignKey("SavingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Savings");
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
