﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Company_Profiles")]
public class CompanyProfilePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Registration_Date")]
    public DateTime RegistrationDate { get; set; }

    [Column("Company_Website")]
    public string? CompanyWebsite { get; set; }

    [Column("Contact_Phone")]
    public string ContactPhone { get; set; }

    [Column("Contact_Name")]
    public string? ContactName { get; set; }

    [Column("Company_Logo")]
    public byte[]? CompanyLogo { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[]? TimeStamp { get; set; }

    // Navigation Properties
    public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
    public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
}