using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Security_Roles")]
public class SecurityRolePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Role")]
    public string Role { get; set; }

    [Column("Is_Inactive")]
    public bool IsInactive { get; set; }

    // Navigation Properties
    public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
}
