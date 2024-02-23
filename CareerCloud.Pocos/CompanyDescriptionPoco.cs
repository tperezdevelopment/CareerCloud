using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Company_Descriptions")]
public class CompanyDescriptionPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Company")]
    public Guid Company { get; set; }

    [Column("LanguageID")]
    public string LanguageId { get; set; }

    [Column("Company_Name")]
    public string CompanyName { get; set; }

    [Column("Company_Description")]
    public string CompanyDescription { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    // Navigation Properties
    public virtual CompanyProfilePoco CompanyProfile { get; set; }
    public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }

}
