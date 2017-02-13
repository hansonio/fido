using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fido.Web.Data;

namespace Fido.Web.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20170213203908_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fido.Web.Models.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data")
                        .IsRequired();

                    b.Property<Guid>("EntityId");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("Size");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Fido.Web.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasMaxLength(254);

                    b.Property<bool>("InActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(125);

                    b.Property<string>("Notes")
                        .HasMaxLength(2147483647);

                    b.Property<bool>("NotifyAdHoc");

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("State")
                        .HasMaxLength(55);

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Zip")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Fido.Web.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(200);

                    b.Property<string>("Memo")
                        .HasMaxLength(500);

                    b.Property<DateTime>("PaymentDateTime");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Fido.Web.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("Breed")
                        .HasMaxLength(100);

                    b.Property<decimal?>("CostPerWalk");

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Notes")
                        .HasMaxLength(2147483647);

                    b.Property<string>("PetType")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("WalkTimes")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Fido.Web.Models.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(2147483647);

                    b.Property<int?>("DurationInMinutes");

                    b.Property<Guid>("PetId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<DateTime?>("WalkDateTime");

                    b.Property<string>("WalkType")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("Fido.Web.Models.Payment", b =>
                {
                    b.HasOne("Fido.Web.Models.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fido.Web.Models.Pet", b =>
                {
                    b.HasOne("Fido.Web.Models.Customer", "Customer")
                        .WithMany("Pets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fido.Web.Models.Walk", b =>
                {
                    b.HasOne("Fido.Web.Models.Pet", "Pet")
                        .WithMany("Walks")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
