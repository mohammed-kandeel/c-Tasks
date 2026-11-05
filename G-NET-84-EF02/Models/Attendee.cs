using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace G_NET_84_EF02.Models;

internal class Attendee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Email { get; set; } = null!;


    [Required]
    [MaxLength(150)]
    public string Street { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column(name: "ZipCode")]
    public string PostalCode { get; set; } = null!;

    [NotMapped]
    public string FullAddress => $"{Street}, {City}, {Country}, {PostalCode}";

    #region Attendee – Badge	
    [InverseProperty(nameof(Badge.Attendee))]
    public Badge? Badge { get; set; }
    #endregion
}