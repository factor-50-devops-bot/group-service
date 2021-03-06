﻿using GroupService.Repo.EntityFramework.Entities;
using GroupService.Repo.Helpers;
using HelpMyStreet.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace GroupService.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            SqlConnection conn = (SqlConnection)Database.GetDbConnection();
            conn.AddAzureToken();
        }

        public virtual DbSet<UserRoleAudit> UserRoleAudit { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<RegistrationJourney> RegistrationJourney { get; set; }
        public virtual DbSet<RequestHelpJourney> RequestHelpJourney { get; set; }
        public virtual DbSet<SecurityConfiguration> SecurityConfigurations { get; set; }

        public virtual DbSet<EnumRole> EnumRole { get; set; }
        public virtual DbSet<EnumTargetGroup> EnumTargetGroup { get; set; }
        public virtual DbSet<EnumRequestHelpFormVariant> EnumRequestHelpFormVariant { get; set; }
        public virtual DbSet<EnumRegistrationFormVariant> EnumRegistrationFormVariant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnumRegistrationFormVariant>(entity =>
            {
                entity.ToTable("RegistrationFormVariant", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.SetEnumRequestHelpFormVariantExtensionsData();
            });

            modelBuilder.Entity<EnumRequestHelpFormVariant>(entity =>
            {
                entity.ToTable("RequestHelpFormVariant", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.SetEnumRequestHelpFormVariantExtensionsData();
            });

            modelBuilder.Entity<EnumRole>(entity =>
            {
                entity.ToTable("Role", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.SetEnumRoleData();
            });

            modelBuilder.Entity<EnumTargetGroup>(entity =>
            {
                entity.ToTable("TargetGroup", "Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.SetEnumTargetGroupData();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group", "Group");

                entity.HasIndex(e => e.GroupKey)
                    .HasName("UC_GroupKey")
                    .IsUnique();

                entity.HasIndex(e => e.GroupName)
                    .HasName("UC_GroupName")
                    .IsUnique();

                entity.SetDefaultGroup();

                entity.HasIndex(e => e.ParentGroupId);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentGroup)
                    .WithMany(p => p.InverseParentGroup)
                    .HasForeignKey(d => d.ParentGroupId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId, e.RoleId });

                entity.ToTable("UserRole", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Group");
            });

            modelBuilder.Entity<UserRoleAudit>(entity =>
            {
                entity.ToTable("UserRoleAudit", "Group");

                entity.HasIndex(e => e.GroupId);

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.AuthorisedByUserId).HasColumnName("AuthorisedByUserID");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<RegistrationJourney>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Source });

                entity.ToTable("RegistrationJourney", "Website");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.RegistrationJourney();

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationFormVariant).HasColumnName("RegistrationFormVariant");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.RegistrationJourney)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationJourney_Group");
            });

            modelBuilder.Entity<RequestHelpJourney>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Source });

                entity.ToTable("RequestHelpJourney", "Website");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.RequestHelpJourney();

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestHelpFormVariant).HasColumnName("RequestHelpFormVariant");

                entity.Property(e => e.TargetGroups).HasColumnName("TargetGroups");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.RequestHelpJourney)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestHelpJourney_Group");
            });

            modelBuilder.Entity<SecurityConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.GroupId });

                entity.ToTable("SecurityConfiguration", "Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.AllowAutonomousJoinersAndLeavers).HasColumnName("AllowAutonomousJoinersAndLeavers")
                                                .HasColumnType("bit").IsRequired(true);

                entity.SetDefaultSecurityConfiguration();

                entity.HasOne(d => d.Group)
                    .WithOne(p => p.SecurityConfiguration)
                    .HasForeignKey<SecurityConfiguration>(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityConfiguration_Group");
            });
        }
    }
}
