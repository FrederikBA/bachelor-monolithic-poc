﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WS.Infrastructure.Data;

#nullable disable

namespace WS.Infrastructure.Migrations
{
    [DbContext(typeof(ChemicalContext))]
    [Migration("20240215093445_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductWarningSentence", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("WarningSentencesId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "WarningSentencesId");

                    b.HasIndex("WarningSentencesId");

                    b.ToTable("ProductWarningSentences", (string)null);
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProducerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProducerAddress", "dbo");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductStatusId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductStatus");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WarningTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WarningTypeId");

                    b.ToTable("WarningCategories");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningPictogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pictogram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WarningPictograms");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WarningCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("WarningPictogramId")
                        .HasColumnType("int");

                    b.Property<int>("WarningSignalWordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WarningCategoryId");

                    b.HasIndex("WarningPictogramId");

                    b.HasIndex("WarningSignalWordId");

                    b.ToTable("WarningSentences");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningSignalWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("SignalWordText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WarningSignalWords");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WarningTypes");
                });

            modelBuilder.Entity("ProductWarningSentence", b =>
                {
                    b.HasOne("WS.Core.Entities.ChemicalAggregate.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WS.Core.Entities.WSAggregate.WarningSentence", null)
                        .WithMany()
                        .HasForeignKey("WarningSentencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.Producer", b =>
                {
                    b.HasOne("WS.Core.Entities.ChemicalAggregate.ProducerAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.Product", b =>
                {
                    b.HasOne("WS.Core.Entities.ChemicalAggregate.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WS.Core.Entities.ChemicalAggregate.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WS.Core.Entities.ChemicalAggregate.ProductStatus", "ProductStatus")
                        .WithMany("Products")
                        .HasForeignKey("ProductStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producer");

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductStatus");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductCategory", b =>
                {
                    b.HasOne("WS.Core.Entities.ChemicalAggregate.ProductGroup", "ProductGroup")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningCategory", b =>
                {
                    b.HasOne("WS.Core.Entities.WSAggregate.WarningType", "WarningType")
                        .WithMany("WarningCategories")
                        .HasForeignKey("WarningTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WarningType");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningSentence", b =>
                {
                    b.HasOne("WS.Core.Entities.WSAggregate.WarningCategory", "WarningCategory")
                        .WithMany("WarningSentences")
                        .HasForeignKey("WarningCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WS.Core.Entities.WSAggregate.WarningPictogram", "WarningPictogram")
                        .WithMany("WarningSentences")
                        .HasForeignKey("WarningPictogramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WS.Core.Entities.WSAggregate.WarningSignalWord", "WarningSignalWordd")
                        .WithMany("WarningSentences")
                        .HasForeignKey("WarningSignalWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WarningCategory");

                    b.Navigation("WarningPictogram");

                    b.Navigation("WarningSignalWordd");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductGroup", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("WS.Core.Entities.ChemicalAggregate.ProductStatus", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningCategory", b =>
                {
                    b.Navigation("WarningSentences");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningPictogram", b =>
                {
                    b.Navigation("WarningSentences");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningSignalWord", b =>
                {
                    b.Navigation("WarningSentences");
                });

            modelBuilder.Entity("WS.Core.Entities.WSAggregate.WarningType", b =>
                {
                    b.Navigation("WarningCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
