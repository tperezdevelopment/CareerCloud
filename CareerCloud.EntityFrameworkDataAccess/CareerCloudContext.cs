using Microsoft.EntityFrameworkCore;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CareerCloudContext : DbContext
{
    // Declaring DbSet
    public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }

    public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
    public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }

    public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }

    public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
    public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
    public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }

    public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }

    public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }

    public DbSet<CompanyJobPoco> CompanyJob { get; set; }

    public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }

    public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }

    public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
    public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
    public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
    public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
    public DbSet<SecurityRolePoco> SecurityRole { get; set; }
    public DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
    public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }


    // Database String
    private readonly string _connectionString = "Data Source=DESKTOP-B7K5FQ1;" +
        "Initial Catalog=JOB_PORTAL_DB;Integrated Security=True; TrustServerCertificate=True";


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ApplicantEducationPoco
        modelBuilder.Entity<ApplicantEducationPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ApplicantEducationPoco>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(ap => ap.ApplicantEducations)
            .IsRequired()
            .HasForeignKey(p => p.Applicant);


        // ApplicantJobApplicationPoco
        modelBuilder.Entity<ApplicantJobApplicationPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ApplicantJobApplicationPoco>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(ap => ap.ApplicantJobApplications)
            .IsRequired()
            .HasForeignKey(p => p.Applicant);

        modelBuilder.Entity<ApplicantJobApplicationPoco>()
            .HasOne(p => p.CompanyJob)
            .WithMany(c => c.ApplicantJobApplications)
            .IsRequired()
            .HasForeignKey(p => p.Job);



        // ApplicantProfilePoco
        modelBuilder.Entity<ApplicantProfilePoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ApplicantProfilePoco>()
            .HasOne(p => p.SecurityLogin)
            .WithMany(s => s.ApplicantProfiles)
            .IsRequired()
            .HasForeignKey(p => p.Login);

        modelBuilder.Entity<ApplicantProfilePoco>()
            .HasOne(p => p.SystemCountryCode)
            .WithMany(sy => sy.ApplicantProfiles)
            .HasForeignKey(p => p.Country);

        // ApplicantResumePoco
        modelBuilder.Entity<ApplicantResumePoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ApplicantResumePoco>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(ap => ap.ApplicantResumes)
            .IsRequired()
            .HasForeignKey(p => p.Applicant);

        // ApplicantSkillPoco
        modelBuilder.Entity<ApplicantSkillPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ApplicantSkillPoco>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(ap => ap.ApplicantSkills)
            .IsRequired()
            .HasForeignKey(p => p.Applicant);

        // ApplicantWorkHistoryPoco
        modelBuilder.Entity<ApplicantWorkHistoryPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ApplicantWorkHistoryPoco>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(ap => ap.ApplicantWorkHistorys)
            .IsRequired()
            .HasForeignKey(p => p.Applicant);

        modelBuilder.Entity<ApplicantWorkHistoryPoco>()
            .HasOne(p => p.SystemCountryCode)
            .WithMany(sy => sy.ApplicantWorkHistories)
            .IsRequired()
            .HasForeignKey(p => p.CountryCode);

        // CompanyDescriptionPoco
        modelBuilder.Entity<CompanyDescriptionPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<CompanyDescriptionPoco>()
            .HasOne(p => p.CompanyProfile)
            .WithMany(c => c.CompanyDescriptions)
            .IsRequired()
            .HasForeignKey(p => p.Company);

        modelBuilder.Entity<CompanyDescriptionPoco>()
            .HasOne(p => p.SystemLanguageCode)
            .WithMany(sl => sl.CompanyDescriptions)
            .IsRequired()
            .HasForeignKey(p => p.LanguageId);

        // CompanyJobDescriptionPoco
        modelBuilder.Entity<CompanyJobDescriptionPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<CompanyJobDescriptionPoco>()
            .HasOne(p => p.CompanyJob)
            .WithMany(c => c.CompanyJobDescriptions)
            .IsRequired()
            .HasForeignKey(p => p.Job);

        // CompanyJobEducationPoco
        modelBuilder.Entity<CompanyJobEducationPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<CompanyJobEducationPoco>()
            .HasOne(p => p.CompanyJob)
            .WithMany(c => c.CompanyJobEducations)
            .IsRequired()
            .HasForeignKey(p => p.Job);

        // CompanyJobPoco
        modelBuilder.Entity<CompanyJobPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<CompanyJobPoco>()
            .HasOne(p => p.CompanyProfile)
            .WithMany(cp => cp.CompanyJobs)
            .IsRequired()
            .HasForeignKey(p => p.Company);

        // CompanyJobSkillPoco
        modelBuilder.Entity<CompanyJobSkillPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<CompanyJobSkillPoco>()
            .HasOne(p => p.CompanyJob)
            .WithMany(cp => cp.CompanyJobSkills)
            .IsRequired()
            .HasForeignKey(p => p.Job);

        // CompanyLocationPoco
        modelBuilder.Entity<CompanyLocationPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<CompanyLocationPoco>()
            .HasOne(p => p.CompanyProfile)
            .WithMany(cp => cp.CompanyLocations)
            .IsRequired()
            .HasForeignKey(p => p.Company);

        modelBuilder.Entity<CompanyLocationPoco>()
            .HasOne(p => p.SystemCountryCode)
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.CountryCode);

        // CompanyProfilePoco
        modelBuilder.Entity<CompanyProfilePoco>()
            .HasKey(p => p.Id);

        // SecurityLoginPoco
        modelBuilder.Entity<SecurityLoginPoco>()
            .HasKey(p => p.Id);

        // SecurityLoginsLogPoco
        modelBuilder.Entity<SecurityLoginsLogPoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<SecurityLoginsLogPoco>()
            .HasOne(p => p.SecurityLogin)
            .WithMany(sl => sl.SecurityLoginsLogs)
            .IsRequired()
            .HasForeignKey(p => p.Login);

        // SecurityLoginsRolePoco
        modelBuilder.Entity<SecurityLoginsRolePoco>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<SecurityLoginsRolePoco>()
            .HasOne(p => p.SecurityLogin)
            .WithMany(sl => sl.SecurityLoginsRoles)
            .IsRequired()
            .HasForeignKey(p => p.Login);

        modelBuilder.Entity<SecurityLoginsRolePoco>()
            .HasOne(p => p.SecurityRole)
            .WithMany(slr => slr.SecurityLoginsRoles)
            .IsRequired()
            .HasForeignKey(p => p.Role);

        // SecurityRolePoco
        modelBuilder.Entity<SecurityRolePoco>()
            .HasKey(p => p.Id);

        // SystemCountryCodePoco
        modelBuilder.Entity<SystemCountryCodePoco>()
            .HasKey(p => p.Code);

        // SystemLanguageCodePoco
        modelBuilder.Entity<SystemLanguageCodePoco>()
            .HasKey(p => p.LanguageID);

    }

}
