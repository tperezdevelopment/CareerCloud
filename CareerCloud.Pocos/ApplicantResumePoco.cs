﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Applicant_Resumes")]
public class ApplicantResumePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Applicant")]
    public Guid Applicant { get; set; }

    [Column("Resume")]
    public string Resume { get; set; }

    [Column("Last_Updated")]
    public DateTime? LastUpdated { get; set; }

    // Navigation Properties
    public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
}
