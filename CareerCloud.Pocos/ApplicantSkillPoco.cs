﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Applicant_Skills")]
public class ApplicantSkillPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Applicant")]
    public Guid Applicant { get; set; }

    [Column("Skill")]
    public string Skill { get; set; }

    [Column("Skill_Level")]
    public string SkillLevel { get; set; }

    [Column("Start_Month")]
    public byte StartMonth { get; set; }

    [Column("Start_Year")]
    public int StartYear { get; set; }

    [Column("End_Month")]
    public byte EndMonth { get; set; }

    [Column("End_Year")]
    public int EndYear { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    // Navigation Properties
    public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
}
