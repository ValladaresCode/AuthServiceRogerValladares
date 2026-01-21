using System.ComponentModel.DataAnnotations; // import
namespace AuthServiceRoger.Domain.Entities;

public class UserProfile{
    [Key]//que sea llave
    [MaxLength(16)]//longitud maxima
    public string Id { get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]
    public string UserId { get; set; } = string.Empty;

    [MaxLength(512)]
    public string ProfilePicture { get; set; } = string.Empty;

    [Required]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "El numero debe tener 8 digitos")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "El telefono solo debe tener numeros")]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public User User { get; set; } = null!;
}