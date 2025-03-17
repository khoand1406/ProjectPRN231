using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectBusinessModel.Models;

public partial class FinalProjectPrn231Context : DbContext
{
    public FinalProjectPrn231Context()
    {
    }

    public FinalProjectPrn231Context(DbContextOptions<FinalProjectPrn231Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyListImage> CompanyListImages { get; set; }

    public virtual DbSet<Cv> Cvs { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobSaved> JobSaveds { get; set; }

    public virtual DbSet<JobTag> JobTags { get; set; }

    public virtual DbSet<JobViewed> JobVieweds { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =DESKTOP-Q6BEF3C; database =FinalProject_PRN231;uid=khoand;pwd=1234; TrustServerCertificate= true; trusted_connection = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CvId).HasColumnName("cv_id");
            entity.Property(e => e.Education)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("education");
            entity.Property(e => e.Experience)
                .IsRequired()
                .HasColumnName("experience");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_Applicants_User");

            entity.HasMany(d => d.Skills).WithMany(p => p.Applicants)
                .UsingEntity<Dictionary<string, object>>(
                    "SkillsApplicant",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Skills_Applicants_Skills"),
                    l => l.HasOne<Applicant>().WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Skills_Applicants_Applicants"),
                    j =>
                    {
                        j.HasKey("ApplicantId", "SkillId");
                        j.ToTable("Skills_Applicants");
                        j.IndexerProperty<int>("ApplicantId").HasColumnName("applicant_id");
                        j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                    });
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.AppliedAt)
                .HasColumnType("datetime")
                .HasColumnName("applied_at");
            entity.Property(e => e.CoverLetter).HasColumnName("cover_letter");
            entity.Property(e => e.CvId).HasColumnName("cv_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK_Applications_Applicants");

            entity.HasOne(d => d.Cv).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CvId)
                .HasConstraintName("FK_Applications_CVs");

            entity.HasOne(d => d.Job).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Applications_Job");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasColumnName("address");
            entity.Property(e => e.CompanyEmail)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_email");
            entity.Property(e => e.CompanyLogo)
                .IsUnicode(false)
                .HasColumnName("company_logo");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasColumnName("company_name");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.EmployeeSize).HasColumnName("employee_size");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.TechStack)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("website");
        });

        modelBuilder.Entity<CompanyListImage>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.ImageSouce)
                .IsUnicode(false)
                .HasColumnName("imageSouce");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyListImages)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CompanyListImages_Company");
        });

        modelBuilder.Entity<Cv>(entity =>
        {
            entity.ToTable("CVs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CvName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("cv_name");
            entity.Property(e => e.CvUrl)
                .IsUnicode(false)
                .HasColumnName("cv_url");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Cvs)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK_CVs_Applicants");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Company).WithMany(p => p.Employers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Employers_Company");

            entity.HasOne(d => d.User).WithMany(p => p.Employers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employers_User");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Benefits).HasColumnName("benefits");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.EmploymentType)
                .HasMaxLength(50)
                .HasColumnName("employment_type");
            entity.Property(e => e.ExpiredAt)
                .HasColumnType("datetime")
                .HasColumnName("expired_at");
            entity.Property(e => e.JobType)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("job_type");
            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.PostedAt)
                .HasColumnType("datetime")
                .HasColumnName("posted_at");
            entity.Property(e => e.Requirements)
                .IsRequired()
                .HasColumnName("requirements");
            entity.Property(e => e.Salary)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("salary");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Job_Company");

            entity.HasMany(d => d.Skills).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Job_Skills_Skills"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Job_Skills_Job"),
                    j =>
                    {
                        j.HasKey("JobId", "SkillId");
                        j.ToTable("Job_Skills");
                        j.IndexerProperty<int>("JobId").HasColumnName("job_id");
                        j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                    });
        });

        modelBuilder.Entity<JobSaved>(entity =>
        {
            entity.ToTable("Job_saved");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.SaveAt)
                .HasColumnType("datetime")
                .HasColumnName("save_at");

            entity.HasOne(d => d.Applicant).WithMany(p => p.JobSaveds)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK_Job_saved_Applicants");

            entity.HasOne(d => d.Job).WithMany(p => p.JobSaveds)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Job_saved_Job");
        });

        modelBuilder.Entity<JobTag>(entity =>
        {
            entity.ToTable("Job_TAgs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Tagname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("tagname");

            entity.HasOne(d => d.Job).WithMany(p => p.JobTags)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Job_TAgs_Job");
        });

        modelBuilder.Entity<JobViewed>(entity =>
        {
            entity.ToTable("Job_viewed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.ViewAt)
                .HasColumnType("datetime")
                .HasColumnName("view_at");

            entity.HasOne(d => d.Applicant).WithMany(p => p.JobVieweds)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK_Job_viewed_Applicants");

            entity.HasOne(d => d.Job).WithMany(p => p.JobVieweds)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Job_viewed_Job");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
