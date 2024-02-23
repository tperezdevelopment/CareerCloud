using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("System_Language_Codes")]
public class SystemLanguageCodePoco
{
    [Key]
    public string LanguageID { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("Native_Name")]
    public string NativeName { get; set; }

    // Navigation Properties
    public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
}
