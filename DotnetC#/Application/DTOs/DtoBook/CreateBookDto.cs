using System.ComponentModel.DataAnnotations;
using DotnetC_.Application.DTOs.DtoImage;

namespace DotnetC_.Application.DTOs.DtoBook;

public class CreateBookDto
{
    [Required]
    [StringLength(255)]
    public string NameBook { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Author { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Isbn { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public double ListPrice { get; set; }

    [Required]
    public double SellPrice { get; set; }

    [Required]
    public int Quantity { get; set; }

    public int DiscountPercent { get; set; }

    public List<int> GenreIds { get; set; } = new List<int>();
    public List<CreateImageDto> Images { get; set; } = new List<CreateImageDto>();
}
