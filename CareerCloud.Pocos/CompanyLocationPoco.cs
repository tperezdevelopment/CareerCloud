﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos;

[Table("Company_Locations")]
public class CompanyLocationPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    [Column("Company")]
    public Guid Company { get; set; }

    [Column("Country_Code")]
    public string CountryCode{ get; set; }

    [Column("State_Province_Code")]
    public string? Province{ get; set; }

    [Column("Street_Address")]
    public string? Street{ get; set; }

    [Column("City_Town")]
    public string? City{ get; set; }

    [Column("Zip_Postal_Code")]
    public string? PostalCode { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Timestamp]
    [Column("Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    // Navigation Properties
    public virtual CompanyProfilePoco CompanyProfile { get; set; }
    public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
}
