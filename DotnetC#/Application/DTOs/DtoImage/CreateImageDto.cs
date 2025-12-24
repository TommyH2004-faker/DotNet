using System.ComponentModel.DataAnnotations;

namespace DotnetC_.Application.DTOs.DtoImage;

public class CreateImageDto
{
    [Required]
    public string NameImage { get; set; } = null!;

    [Required]
    public string UrlImage { get; set; } = null!;

    public bool IsThumbnail { get; set; }
}
