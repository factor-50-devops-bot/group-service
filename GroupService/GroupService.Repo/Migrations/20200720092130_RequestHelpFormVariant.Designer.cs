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
    [Migration("20200720092130_RequestHelpFormVariant")]
    partial class RequestHelpFormVariant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumRequestHelpFormVariant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RequestHelpFormVariant","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "VitalsForVeterans"
                        },
                        new
                        {
                            Id = 3,
                            Name = "DIY"
                        },
                        new
                        {
                            Id = 4,
                            Name = "FtLOS"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Member"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TaskAdmin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "UserAdmin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Owner"
                        },
                        new
                        {
                            Id = 5,
                            Name = "RequestSubmitter"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumTargetGroup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TargetGroup","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "ThisGroup"
                        },
                        new
                        {
                            Id = 1,
                            Name = "ThisGroupAndChildren"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ParentGroup"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SiblingsAndParentGroup"
                        },
                        new
                        {
                            Id = 4,
                            Name = "GenericGroup"
                        });
                });

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
                        },
                        new
                        {
                            Id = -2,
                            GroupKey = "ftlos",
                            GroupName = "For the Love of Scrubs"
                        },
                        new
                        {
                            Id = -3,
                            GroupKey = "ageuklsl",
                            GroupName = "Age UK Lincoln & South Lincolnshire"
                        },
                        new
                        {
                            Id = -4,
                            GroupKey = "hlp",
                            GroupName = "Healthy London Partnership"
                        },
                        new
                        {
                            Id = -5,
                            GroupKey = "tankersley",
                            GroupName = "Tankersley & Pilley"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RegistrationJourney", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID");

                    b.Property<string>("Source")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("RegistrationFormVariant")
                        .HasColumnName("RegistrationFormVariant");

                    b.HasKey("GroupId", "Source");

                    b.ToTable("RegistrationJourney","Website");

                    b.HasData(
                        new
                        {
                            GroupId = -1,
                            Source = "",
                            RegistrationFormVariant = (byte)0
                        },
                        new
                        {
                            GroupId = -2,
                            Source = "",
                            RegistrationFormVariant = (byte)2
                        },
                        new
                        {
                            GroupId = -3,
                            Source = "",
                            RegistrationFormVariant = (byte)3
                        },
                        new
                        {
                            GroupId = -4,
                            Source = "",
                            RegistrationFormVariant = (byte)1
                        },
                        new
                        {
                            GroupId = -5,
                            Source = "",
                            RegistrationFormVariant = (byte)0
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RequestHelpJourney", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID");

                    b.Property<string>("Source")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("RequestHelpFormVariant")
                        .HasColumnName("RequestHelpFormVariant");

                    b.Property<byte>("TargetGroups")
                        .HasColumnName("TargetGroups");

                    b.HasKey("GroupId", "Source");

                    b.ToTable("RequestHelpJourney","Website");

                    b.HasData(
                        new
                        {
                            GroupId = -1,
                            Source = "DIY",
                            RequestHelpFormVariant = (byte)3,
                            TargetGroups = (byte)4
                        },
                        new
                        {
                            GroupId = -1,
                            Source = "",
                            RequestHelpFormVariant = (byte)1,
                            TargetGroups = (byte)4
                        },
                        new
                        {
                            GroupId = -2,
                            Source = "",
                            RequestHelpFormVariant = (byte)4,
                            TargetGroups = (byte)1
                        },
                        new
                        {
                            GroupId = -3,
                            Source = "",
                            RequestHelpFormVariant = (byte)2,
                            TargetGroups = (byte)4
                        },
                        new
                        {
                            GroupId = -4,
                            Source = "",
                            RequestHelpFormVariant = (byte)1,
                            TargetGroups = (byte)0
                        },
                        new
                        {
                            GroupId = -5,
                            Source = "",
                            RequestHelpFormVariant = (byte)1,
                            TargetGroups = (byte)4
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

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RegistrationJourney", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("RegistrationJourney")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_RegistrationJourney_Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RequestHelpJourney", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("RequestHelpJourney")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_RequestHelpJourney_Group");
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
