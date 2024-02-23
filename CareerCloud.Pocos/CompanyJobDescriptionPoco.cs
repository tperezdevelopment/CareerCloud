using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Company_Jobs_Descriptions")]
public class CompanyJobDescriptionPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Job")]
    public Guid Job { get; set; }

    [Column("Job_Name")]
    public string? JobName { get; set; }

    [Column("Job_Descriptions")]
    public string? JobDescriptions { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[]? TimeStamp { get; set; }

    // Navigation Properties
    public virtual CompanyJobPoco CompanyJob { get; set; }
}
