﻿// <auto-generated />
using System;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorApp.Data.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20210704135300_AddExpenseToIncome")]
    partial class AddExpenseToIncome
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");

            modelBuilder.Entity("BlazorApp.Data.Models.Budget", b =>
                {
                    b.Property<int>("YearMonth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("YearMonth");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BudgetYearMonth")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("IncomeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasMaxLength(800)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetYearMonth");

                    b.HasIndex("IncomeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BudgetYearMonth")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetYearMonth");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Expense", b =>
                {
                    b.HasOne("BlazorApp.Data.Models.Budget", null)
                        .WithMany("Expenses")
                        .HasForeignKey("BudgetYearMonth");

                    b.HasOne("BlazorApp.Data.Models.Income", null)
                        .WithMany("Expenses")
                        .HasForeignKey("IncomeId");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Income", b =>
                {
                    b.HasOne("BlazorApp.Data.Models.Budget", null)
                        .WithMany("Incomes")
                        .HasForeignKey("BudgetYearMonth");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Budget", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("BlazorApp.Data.Models.Income", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}