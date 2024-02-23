using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Company_Job_Educations")]
public class CompanyJobEducationPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Job")]
    public Guid Job { get; set; }

    [Column("Major")]
    public string Major { get; set; }

    [Column("Importance")]
    public short Importance { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    // Navigation Properties
    public virtual CompanyJobPoco CompanyJob { get; set; }
}
