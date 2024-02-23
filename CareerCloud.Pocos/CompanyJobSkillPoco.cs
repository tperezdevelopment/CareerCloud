using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Company_Job_Skills")]
public class CompanyJobSkillPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Job")]
    public Guid Job { get; set; }

    [Column("Skill")]
    public string Skill { get; set; }

    [Column("Skill_Level")]
    public string SkillLevel { get; set; }

    [Column("Importance")]
    public int Importance { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    // Navigation Properties
    public virtual CompanyJobPoco CompanyJob { get; set; }
}
