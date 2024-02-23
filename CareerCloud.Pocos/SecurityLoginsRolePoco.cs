using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Security_Logins_Roles")]
public class SecurityLoginsRolePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Login")]
    public Guid Login { get; set; }

    [Column("Role")]
    public Guid Role { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[]? TimeStamp { get; set; }

    // Navigation Properties
    public virtual SecurityLoginPoco SecurityLogin { get; set; }
    public virtual SecurityRolePoco SecurityRole { get; set; }
}
