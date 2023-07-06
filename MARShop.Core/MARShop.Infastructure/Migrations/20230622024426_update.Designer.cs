﻿// <auto-generated />
using System;
using MARShop.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MARShop.Infastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230622024426_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MARShop.Core.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSendEmailWhenHaveNewPost")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LinkWeb")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = "46370d24-50fa-4902-b001-97e13de8ff7b",
                            Created = new DateTime(2023, 6, 22, 9, 44, 25, 344, DateTimeKind.Local).AddTicks(5074),
                            IsDelete = false,
                            IsSendEmailWhenHaveNewPost = false,
                            LastModified = new DateTime(2023, 6, 22, 9, 44, 25, 346, DateTimeKind.Local).AddTicks(3281),
                            Password = "$2a$11$96ow5KjQKR8yhdXBKWBovuwJu/6QlcubevthZKpxv0XWZQ7AGjuuG",
                            Role = "Admin",
                            UserName = "superadmin"
                        });
                });

            modelBuilder.Entity("MARShop.Core.Entities.AccountBlogPost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("BlogPostId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSendEmailWhenHaveNewComment")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("AccountBlogPosts");
                });

            modelBuilder.Entity("MARShop.Core.Entities.BlogPost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Views")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("MARShop.Core.Entities.BlogPostTag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BlogPostId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TagId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("TagId");

                    b.ToTable("BlogPostTags");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("BlogPostId")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ParentId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Facebook")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Linkedin")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = "49f6b60d-7734-470a-965b-e0d87f710fd5",
                            Created = new DateTime(2023, 6, 22, 9, 44, 25, 658, DateTimeKind.Local).AddTicks(2845),
                            Facebook = "",
                            IsDelete = false,
                            LastModified = new DateTime(2023, 6, 22, 9, 44, 25, 658, DateTimeKind.Local).AddTicks(2879),
                            Linkedin = ""
                        });
                });

            modelBuilder.Entity("MARShop.Core.Entities.EmailConfig", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AppPassword")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("EmailConfigs");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Notify", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notifies");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MARShop.Core.Entities.AccountBlogPost", b =>
                {
                    b.HasOne("MARShop.Core.Entities.Account", "Account")
                        .WithMany("AccountBlogPosts")
                        .HasForeignKey("AccountId");

                    b.HasOne("MARShop.Core.Entities.BlogPost", "BlogPost")
                        .WithMany("AccountBlogPosts")
                        .HasForeignKey("BlogPostId");

                    b.Navigation("Account");

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("MARShop.Core.Entities.BlogPostTag", b =>
                {
                    b.HasOne("MARShop.Core.Entities.BlogPost", "BlogPost")
                        .WithMany("BlogPostTags")
                        .HasForeignKey("BlogPostId");

                    b.HasOne("MARShop.Core.Entities.Tag", "Tag")
                        .WithMany("BlogPostTags")
                        .HasForeignKey("TagId");

                    b.Navigation("BlogPost");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Comment", b =>
                {
                    b.HasOne("MARShop.Core.Entities.Account", "Account")
                        .WithMany("Comments")
                        .HasForeignKey("AccountId");

                    b.HasOne("MARShop.Core.Entities.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId");

                    b.Navigation("Account");

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Account", b =>
                {
                    b.Navigation("AccountBlogPosts");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MARShop.Core.Entities.BlogPost", b =>
                {
                    b.Navigation("AccountBlogPosts");

                    b.Navigation("BlogPostTags");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MARShop.Core.Entities.Tag", b =>
                {
                    b.Navigation("BlogPostTags");
                });
#pragma warning restore 612, 618
        }
    }
}