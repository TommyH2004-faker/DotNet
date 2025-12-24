using FluentValidation;
using DotnetC_.Application.DTOs.DtoBook;

namespace DotnetC_.Application.Validators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.NameBook)
            .NotEmpty().WithMessage("Tên sách không được để trống")
            .MaximumLength(255).WithMessage("Tên sách không được vượt quá 255 ký tự");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Tác giả không được để trống")
            .MaximumLength(255).WithMessage("Tên tác giả không được vượt quá 255 ký tự");

        RuleFor(x => x.Isbn)
            .NotEmpty().WithMessage("ISBN không được để trống")
            .MaximumLength(50).WithMessage("ISBN không được vượt quá 50 ký tự");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Mô tả không được để trống");

        RuleFor(x => x.ListPrice)
            .GreaterThan(0).WithMessage("Giá niêm yết phải lớn hơn 0");

        RuleFor(x => x.SellPrice)
            .GreaterThan(0).WithMessage("Giá bán phải lớn hơn 0")
            .LessThanOrEqualTo(x => x.ListPrice).WithMessage("Giá bán không được lớn hơn giá niêm yết");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Số lượng phải lớn hơn hoặc bằng 0");

        RuleFor(x => x.DiscountPercent)
            .InclusiveBetween(0, 100).WithMessage("Phần trăm giảm giá phải từ 0 đến 100");
    }
}