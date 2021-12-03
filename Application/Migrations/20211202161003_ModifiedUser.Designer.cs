﻿// <auto-generated />
using System;
using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211202161003_ModifiedUser")]
    partial class ModifiedUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApplicationCore.InvitationProject", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("UserGuid");

                    b.Property<Guid>("ProjectGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("ProjectGuid");

                    b.HasKey("UserGuid", "ProjectGuid");

                    b.HasIndex("ProjectGuid");

                    b.ToTable("InvitationProject");
                });

            modelBuilder.Entity("ApplicationCore.MemberProject", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("UserGuid");

                    b.Property<Guid>("ProjectGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("ProjectGuid");

                    b.HasKey("UserGuid", "ProjectGuid");

                    b.HasIndex("ProjectGuid");

                    b.ToTable("MemberProject");
                });

            modelBuilder.Entity("ApplicationCore.Project.Project", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Guid");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ApplicationCore.RequestProject", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("UserGuid");

                    b.Property<Guid>("ProjectGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("ProjectGuid");

                    b.HasKey("UserGuid", "ProjectGuid");

                    b.HasIndex("ProjectGuid");

                    b.ToTable("RequestProject");
                });

            modelBuilder.Entity("ApplicationCore.User.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext");

                    b.HasKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApplicationCore.InvitationProject", b =>
                {
                    b.HasOne("ApplicationCore.Project.Project", "Project")
                        .WithMany("Invitations")
                        .HasForeignKey("ProjectGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.User.User", "User")
                        .WithMany("Invitations")
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.MemberProject", b =>
                {
                    b.HasOne("ApplicationCore.Project.Project", "Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.User.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.RequestProject", b =>
                {
                    b.HasOne("ApplicationCore.Project.Project", "Project")
                        .WithMany("Requests")
                        .HasForeignKey("ProjectGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.User.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Project.Project", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Members");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("ApplicationCore.User.User", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Projects");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
