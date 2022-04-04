﻿// <auto-generated />
using System;
using Diagraph.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diagraph.Infrastructure.Migrations
{
    [DbContext(typeof(DiagraphDbContext))]
    [Migration("20220404205702_user-data")]
    partial class userdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("CustomData")
                        .HasColumnType("jsonb")
                        .HasColumnName("custom_data");

                    b.Property<DateTime>("OccurredAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("occurred_at_utc");

                    b.Property<string>("Text")
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at_utc");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.EventTag", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at_utc");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at_utc");

                    b.HasKey("EventId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("event_tag", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.GlucoseMeasurement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at_utc");

                    b.Property<int>("ImportId")
                        .HasColumnType("integer")
                        .HasColumnName("import_id");

                    b.Property<float>("Level")
                        .HasColumnType("real")
                        .HasColumnName("level");

                    b.Property<DateTime>("TakenAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("taken_at");

                    b.Property<int>("Unit")
                        .HasColumnType("integer")
                        .HasColumnName("unit");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at_utc");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ImportId");

                    b.HasIndex("UserId");

                    b.ToTable("glucose_measurement", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Import", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("Hash")
                        .HasColumnType("text")
                        .HasColumnName("hash");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at_utc");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("import", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at_utc");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tag", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("Locked")
                        .HasColumnType("boolean")
                        .HasColumnName("locked");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<int>("UnsuccsessfulLoginAttempts")
                        .HasColumnType("integer")
                        .HasColumnName("unsuccessful_login_attempts");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb")
                        .HasColumnName("data");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at_utc");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("user_profile", (string)null);
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Event", b =>
                {
                    b.HasOne("Diagraph.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.EventTag", b =>
                {
                    b.HasOne("Diagraph.Infrastructure.Models.Event", null)
                        .WithMany("Tags")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diagraph.Infrastructure.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.GlucoseMeasurement", b =>
                {
                    b.HasOne("Diagraph.Infrastructure.Models.Import", null)
                        .WithMany("Measurements")
                        .HasForeignKey("ImportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diagraph.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Import", b =>
                {
                    b.HasOne("Diagraph.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Tag", b =>
                {
                    b.HasOne("Diagraph.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Event", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Diagraph.Infrastructure.Models.Import", b =>
                {
                    b.Navigation("Measurements");
                });
#pragma warning restore 612, 618
        }
    }
}
