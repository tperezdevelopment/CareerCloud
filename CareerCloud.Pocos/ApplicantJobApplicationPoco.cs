using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CareerCloud.Pocos;

[Table("Applicant_Job_Applications")]
public class ApplicantJobApplicationPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Applicant")]
    public Guid Applicant { get; set; }

    [Column("Job")]
    public Guid Job { get; set; }

    [Column("Application_Date")]
    public DateTime ApplicationDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    // Navigation Properties
    public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    public virtual CompanyJobPoco CompanyJob { get; set; }
}
