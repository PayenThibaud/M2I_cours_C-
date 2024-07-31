﻿// <auto-generated />
using System;
using Demo02Relations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo02Relations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119135302_PostTag")]
    partial class PostTag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlogTag", b =>
                {
                    b.Property<int>("BlogsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("BlogsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("BlogTag");
                });

            modelBuilder.Entity("Demo02Relations.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "JohnnyHalliday115",
                            Url = "http://www.johnnyhalliday115.skyblog.com"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Koreus",
                            Url = "http://www.koreus.com"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Toto",
                            Url = "http://www.toto.com"
                        });
                });

            modelBuilder.Entity("Demo02Relations.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 1,
                            Contenu = "Trop triste :'(",
                            DatePublication = new DateTime(2024, 1, 19, 14, 53, 2, 240, DateTimeKind.Local).AddTicks(8736),
                            Titre = "Johnny est mort."
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 2,
                            Contenu = "Le chat il tombe là",
                            DatePublication = new DateTime(2024, 1, 19, 14, 53, 2, 240, DateTimeKind.Local).AddTicks(8773),
                            Titre = "Trop mdr xd la vidéo OLALALA"
                        },
                        new
                        {
                            Id = 3,
                            BlogId = 3,
                            Contenu = "Moi non plus la porte était fermée ^^",
                            DatePublication = new DateTime(2024, 1, 19, 14, 53, 2, 240, DateTimeKind.Local).AddTicks(8775),
                            Titre = "Tu connais la blague de toto aux toilettes ?"
                        });
                });

            modelBuilder.Entity("Demo02Relations.Models.PostTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("Demo02Relations.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BlogTag", b =>
                {
                    b.HasOne("Demo02Relations.Models.Blog", null)
                        .WithMany()
                        .HasForeignKey("BlogsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo02Relations.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demo02Relations.Models.Post", b =>
                {
                    b.HasOne("Demo02Relations.Models.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Demo02Relations.Models.PostTag", b =>
                {
                    b.HasOne("Demo02Relations.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo02Relations.Models.Tag", "Tag")
                        .WithMany("TagPosts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Demo02Relations.Models.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Demo02Relations.Models.Post", b =>
                {
                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("Demo02Relations.Models.Tag", b =>
                {
                    b.Navigation("TagPosts");
                });
#pragma warning restore 612, 618
        }
    }
}