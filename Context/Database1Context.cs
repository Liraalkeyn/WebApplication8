using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Context;

public partial class Database1Context : DbContext
{
    public Database1Context()
    {
    }

    public Database1Context(DbContextOptions<Database1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<RepairPart> RepairParts { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<TechType> TechTypes { get; set; }

    public virtual DbSet<TypeUser> TypeUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=database1;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("clientID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("feedbackID");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.RequestId).HasColumnName("requestID");

            entity.HasOne(d => d.Request).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_feedback_request");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.ToTable("master");

            entity.Property(e => e.MasterId)
                .ValueGeneratedNever()
                .HasColumnName("masterID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("message");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("messageID");
            entity.Property(e => e.MasterId).HasColumnName("masterID");
            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.Text)
                .HasMaxLength(128)
                .HasColumnName("text");

            entity.HasOne(d => d.Master).WithMany(p => p.Messages)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_message_master");

            entity.HasOne(d => d.Request).WithMany(p => p.Messages)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_message_request");
        });

        modelBuilder.Entity<RepairPart>(entity =>
        {
            entity.ToTable("repairPart");

            entity.Property(e => e.RepairPartId)
                .ValueGeneratedNever()
                .HasColumnName("repairPartID");
            entity.Property(e => e.MasterId).HasColumnName("masterID");
            entity.Property(e => e.Repair).HasColumnName("repair");
            entity.Property(e => e.TechTypeId).HasColumnName("techTypeID");

            entity.HasOne(d => d.Master).WithMany(p => p.RepairParts)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_repairPart_master");

            entity.HasOne(d => d.TechType).WithMany(p => p.RepairParts)
                .HasForeignKey(d => d.TechTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_repairPart_techType");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("request");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("requestID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.ClimateTechModel).HasColumnName("climateTechModel");
            entity.Property(e => e.CompletionDate).HasColumnName("completionDate");
            entity.Property(e => e.MasterId).HasColumnName("masterID");
            entity.Property(e => e.ProblemDescryption).HasColumnName("problemDescryption");
            entity.Property(e => e.RepairPartsId).HasColumnName("repairPartsID");
            entity.Property(e => e.RequestStatusId).HasColumnName("requestStatusID");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.TechTypeId).HasColumnName("techTypeID");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_request_client1");

            entity.HasOne(d => d.Master).WithMany(p => p.Requests)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK_request_master");

            entity.HasOne(d => d.RepairParts).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RepairPartsId)
                .HasConstraintName("FK_request_repairPart");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestStatusId)
                .HasConstraintName("FK_request_requestStatus");

            entity.HasOne(d => d.TechType).WithMany(p => p.Requests)
                .HasForeignKey(d => d.TechTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_request_techType");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.ToTable("requestStatus");

            entity.Property(e => e.RequestStatusId)
                .ValueGeneratedNever()
                .HasColumnName("requestStatusID");
            entity.Property(e => e.Message)
                .HasMaxLength(128)
                .HasColumnName("message");
        });

        modelBuilder.Entity<TechType>(entity =>
        {
            entity.ToTable("techType");

            entity.Property(e => e.TechTypeId)
                .ValueGeneratedNever()
                .HasColumnName("techTypeID");
            entity.Property(e => e.ClimateTechType)
                .HasMaxLength(128)
                .HasColumnName("climateTechType");
        });

        modelBuilder.Entity<TypeUser>(entity =>
        {
            entity.ToTable("typeUser");

            entity.Property(e => e.TypeUserId)
                .ValueGeneratedNever()
                .HasColumnName("typeUserID");
            entity.Property(e => e.NameOfType)
                .HasMaxLength(50)
                .HasColumnName("nameOfType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.TypeUserId).HasColumnName("typeUserID");

            entity.HasOne(d => d.TypeUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_typeUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
