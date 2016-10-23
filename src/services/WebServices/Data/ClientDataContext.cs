using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebServices.Data.Entities;

namespace WebServices.Data
{
    public class ClientDataContext : DbContext
    {
        public DbSet<CaseWorker> CaseWorkers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CourtCase> CourtCases { get; set; }
        public DbSet<Disabilitie> Disabilities { get; set; }
        public DbSet<EmploymentEducation> EmploymentEducations { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Exit> Exits { get; set; }
        public DbSet<Funder> Funders { get; set; }
        public DbSet<HealthAndDV> HealthAndDvs { get; set; }
        public DbSet<IncomeBenefit> IncomeBenefits { get; set; }
        public DbSet<IncomingRiskFactor> IncomingRiskFactors { get; set; }
        public DbSet<RiskNote> RiskNotes { get; set; }
        public DbSet<Service> Services { get; set; }

        public ClientDataContext()
            : base("SqlConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseWorker>()
                .ToTable("CaseWorkers")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .ToTable("Client")
                .HasKey(c => c.UUID);

            modelBuilder.Entity<CourtCase>()
                .ToTable("CourtCases")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Disabilitie>()
                .ToTable("Disabilities")
                .HasKey(d => d.DisabilitiesID)
                .HasRequired(d => d.Client)
                .WithMany(c => c.Disabilities)
                .HasForeignKey(d => d.PersonalID);

            modelBuilder.Entity<EmploymentEducation>()
                .ToTable("EmploymentEducation")
                .HasKey(e => e.EmploymentEducationID)
                .HasRequired(e => e.Client)
                .WithMany(c => c.EmploymentEducations)
                .HasForeignKey(e => e.PersonalID);

            modelBuilder.Entity<Enrollment>()
                .ToTable("Enrollment")
                .HasKey(e => e.EnrollmentID)
                .HasRequired(e => e.Client)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.PersonalID);

            modelBuilder.Entity<Exit>()
                .ToTable("Exit")
                .HasRequired(e => e.Client)
                .WithMany(c => c.Exits)
                .HasForeignKey(e => e.PersonalID);

            modelBuilder.Entity<Funder>()
                .ToTable("Funder")
                .HasKey(f => f.FunderID)
                .Property(f => f.FunderOther)
                .HasColumnName("Funder");

            modelBuilder.Entity<HealthAndDV>()
                .ToTable("HealthAndDV")
                .HasKey(h => h.HealthAndDVID)
                .HasRequired(h => h.Client)
                .WithMany(c => c.HealthAndDvs)
                .HasForeignKey(h => h.PersonalID);

            modelBuilder.Entity<IncomeBenefit>()
                .ToTable("IncomeBenefits")
                .HasKey(i => i.IncomeBenefitsID)
                .HasRequired(i => i.Client)
                .WithMany(c => c.IncomeBenefits)
                .HasForeignKey(i => i.PersonalID);

            modelBuilder.Entity<IncomingRiskFactor>()
                .ToTable("IncomingRiskFactors")
                .HasKey(i => i.Id)
                .HasRequired(i => i.CaseWorker)
                .WithMany(c => c.IncomingRiskFactors)
                .HasForeignKey(i => i.CaseWorkerId);

            modelBuilder.Entity<RiskNote>()
                .ToTable("RiskNotes")
                .HasKey(r => r.Id)
                .HasRequired(r => r.IncomingRiskFactor)
                .WithMany(i => i.RiskNotes)
                .HasForeignKey(r => r.RiskId);

            modelBuilder.Entity<Service>()
                .ToTable("Services")
                .HasKey(s => s.ServicesID)
                .HasRequired(s => s.Client)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.PersonalID);
        }
    }
}