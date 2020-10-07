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
    [Migration("20201007110603_PopulateUserTables")]
    partial class PopulateUserTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.ActivityCredentialSet", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnName("ActivityID")
                        .HasColumnType("int");

                    b.Property<int>("CredentialSetId")
                        .HasColumnName("CredentialSetID")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "ActivityId", "CredentialSetId");

                    b.ToTable("ActivityCredentialSet","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.Credential", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Credential","Group");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "IdentityVerifiedByYoti"
                        },
                        new
                        {
                            Id = 1,
                            Name = "ManuallyVerified"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.CredentialSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("CredentialId")
                        .HasColumnName("CredentialID")
                        .HasColumnType("int");

                    b.HasKey("Id", "GroupId", "CredentialId");

                    b.HasIndex("CredentialId");

                    b.HasIndex("GroupId");

                    b.ToTable("CredentialSet","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumCredentialTypes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CredentialTypes","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IdentityVerification"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ThirdPartyCheck"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Training"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumRegistrationFormVariant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegistrationFormVariant","Lookup");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 1,
                            Name = "HLP"
                        },
                        new
                        {
                            Id = 2,
                            Name = "FtLOS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AgeUKLSL"
                        },
                        new
                        {
                            Id = 4,
                            Name = "FaceMasks"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumRequestHelpFormVariant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                        },
                        new
                        {
                            Id = 5,
                            Name = "FaceMasks"
                        },
                        new
                        {
                            Id = 6,
                            Name = "HLP_CommunityConnector"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ruddington"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                        },
                        new
                        {
                            Id = 6,
                            Name = "Volunteer"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.EnumTargetGroup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("ParentGroupId")
                        .HasColumnType("int");

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
                        },
                        new
                        {
                            Id = -6,
                            GroupKey = "ruddington",
                            GroupName = "Ruddington"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.GroupCredential", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("CredentialId")
                        .HasColumnName("CredentialID")
                        .HasColumnType("int");

                    b.Property<byte>("CredentialTypeId")
                        .HasColumnName("CredentialTypeID")
                        .HasColumnType("tinyint");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("HowToAchieve")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("GroupId", "CredentialId")
                        .HasName("PK_GROUP_CREDENTIAL");

                    b.HasIndex("CredentialId");

                    b.ToTable("GroupCredential","Group");

                    b.HasData(
                        new
                        {
                            GroupId = -1,
                            CredentialId = -1,
                            CredentialTypeId = (byte)1,
                            DisplayOrder = 1,
                            HowToAchieve = "Use Yoti App",
                            Name = "Yoti Identity Verification"
                        },
                        new
                        {
                            GroupId = -2,
                            CredentialId = -1,
                            CredentialTypeId = (byte)1,
                            DisplayOrder = 1,
                            HowToAchieve = "Use Yoti App",
                            Name = "Yoti Identity Verification"
                        },
                        new
                        {
                            GroupId = -2,
                            CredentialId = 1,
                            CredentialTypeId = (byte)1,
                            DisplayOrder = 2,
                            HowToAchieve = "Email someone",
                            Name = "Yoti Identity Verification"
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RegistrationJourney", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("RegistrationFormVariant")
                        .HasColumnName("RegistrationFormVariant")
                        .HasColumnType("tinyint");

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
                            GroupId = -1,
                            Source = "face-masks",
                            RegistrationFormVariant = (byte)4
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
                        },
                        new
                        {
                            GroupId = -6,
                            Source = "",
                            RegistrationFormVariant = (byte)0
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RequestHelpJourney", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("RequestHelpFormVariant")
                        .HasColumnName("RequestHelpFormVariant")
                        .HasColumnType("tinyint");

                    b.Property<byte>("TargetGroups")
                        .HasColumnName("TargetGroups")
                        .HasColumnType("tinyint");

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
                            GroupId = -1,
                            Source = "face-masks",
                            RequestHelpFormVariant = (byte)5,
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
                            Source = "connected-together-service-directory",
                            RequestHelpFormVariant = (byte)6,
                            TargetGroups = (byte)0
                        },
                        new
                        {
                            GroupId = -5,
                            Source = "",
                            RequestHelpFormVariant = (byte)1,
                            TargetGroups = (byte)4
                        },
                        new
                        {
                            GroupId = -6,
                            Source = "",
                            RequestHelpFormVariant = (byte)7,
                            TargetGroups = (byte)0
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.SecurityConfiguration", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<bool>("AllowAutonomousJoinersAndLeavers")
                        .HasColumnName("AllowAutonomousJoinersAndLeavers")
                        .HasColumnType("bit");

                    b.HasKey("GroupId");

                    b.ToTable("SecurityConfiguration","Group");

                    b.HasData(
                        new
                        {
                            GroupId = -6,
                            AllowAutonomousJoinersAndLeavers = true
                        });
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserCredential", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.Property<int>("CredentialId")
                        .HasColumnName("CredentialID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorisedByUserId")
                        .HasColumnName("AuthorisedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("Reference")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ValidUntil")
                        .HasColumnType("datetime");

                    b.HasKey("GroupId", "UserId", "CredentialId");

                    b.HasIndex("CredentialId");

                    b.ToTable("UserCredential","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserRole", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "UserId", "RoleId");

                    b.ToTable("UserRole","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserRoleAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ActionId")
                        .HasColumnName("ActionID")
                        .HasColumnType("tinyint");

                    b.Property<int>("AuthorisedByUserId")
                        .HasColumnName("AuthorisedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime");

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID")
                        .HasColumnType("int");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UserRoleAudit","Group");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.ActivityCredentialSet", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("ActivityCredentialSet")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_ActivityCredentialSet_GroupID")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.CredentialSet", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Credential", "Credential")
                        .WithMany("CredentialSet")
                        .HasForeignKey("CredentialId")
                        .HasConstraintName("FK_CredentialSet_CredentialID")
                        .IsRequired();

                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("CredentialSet")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_CredentialSet_GroupID")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.Group", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "ParentGroup")
                        .WithMany("InverseParentGroup")
                        .HasForeignKey("ParentGroupId");
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.GroupCredential", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Credential", "Credential")
                        .WithMany("GroupCredential")
                        .HasForeignKey("CredentialId")
                        .HasConstraintName("FK_GroupCredential_CredentialID")
                        .IsRequired();

                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("GroupCredential")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_GroupCredential_Group")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RegistrationJourney", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("RegistrationJourney")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_RegistrationJourney_Group")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.RequestHelpJourney", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("RequestHelpJourney")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_RequestHelpJourney_Group")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.SecurityConfiguration", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithOne("SecurityConfiguration")
                        .HasForeignKey("GroupService.Repo.EntityFramework.Entities.SecurityConfiguration", "GroupId")
                        .HasConstraintName("FK_SecurityConfiguration_Group")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserCredential", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Credential", "Credential")
                        .WithMany("UserCredential")
                        .HasForeignKey("CredentialId")
                        .HasConstraintName("FK_UserCredential_CredentialID")
                        .IsRequired();

                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("UserCredential")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_UserCredential_GroupID")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupService.Repo.EntityFramework.Entities.UserRole", b =>
                {
                    b.HasOne("GroupService.Repo.EntityFramework.Entities.Group", "Group")
                        .WithMany("UserRole")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Role_Group")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
