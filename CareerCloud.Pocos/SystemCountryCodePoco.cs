using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("System_Country_Codes")]
public class SystemCountryCodePoco
{
    [Key]
    public string Code { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    // Navigation Properties
    public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }    

}
