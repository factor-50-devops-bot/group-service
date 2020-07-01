﻿// <auto-generated />
using System;
using GroupService.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroupService.Repo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200701141739_AddGroupKey")]
    partial class AddGroupKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupKey");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("ParentGroupId");

                    b.HasKey("Id");

                    b.HasIndex("GroupKey")
                        .IsUnique()
                        .HasName("UC_GroupKey")
                        .HasFilter("[GroupKey] IS NOT NULL");

                    b.HasIndex("GroupName")
                        .IsUnique()
                        .HasName("UC_GroupName");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("Group","Group");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            GroupKey = "Generic",
                            GroupName = "Generic"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserRole", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID");

                    b.HasKey("GroupId", "UserId", "RoleId");

                    b.ToTable("UserRole","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserRoleAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ActionId")
                        .HasColumnName("ActionID");

                    b.Property<int>("AuthorisedByUserId")
                        .HasColumnName("AuthorisedByUserID");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime");

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID");

                    b.Property<bool>("Success");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UserRoleAudit","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.Group", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "ParentGroup")
                        .WithMany("InverseParentGroup")
                        .HasForeignKey("ParentGroupId");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserRole", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("UserRole")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Role_Group");
                });
#pragma warning restore 612, 618
        }
    }
}
