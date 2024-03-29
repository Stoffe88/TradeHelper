﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeHelper.Database;

namespace TradeHelper.Migrations
{
    [DbContext(typeof(TradeHelperContext))]
    partial class TradeHelperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradeHelper.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<bool>("NameIsEdited")
                        .HasColumnType("bit");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("ValueIsEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ValueUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("TradeHelper.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Transaction");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("TradeHelper.Models.StockTransaction", b =>
                {
                    b.HasBaseType("TradeHelper.Models.Transaction");

                    b.Property<int>("StockCount")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasIndex("StockId");

                    b.HasDiscriminator().HasValue("StockTransaction");
                });

            modelBuilder.Entity("TradeHelper.Models.StockTransaction", b =>
                {
                    b.HasOne("TradeHelper.Models.Stock", "Stock")
                        .WithMany("Transactions")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
