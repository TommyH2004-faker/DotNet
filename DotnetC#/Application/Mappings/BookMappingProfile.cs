using AutoMapper;
using DotnetC_.Application.DTOs.DtoBook;
using DotnetC_.Domain.Entities;

namespace DotnetC_.Application.Mappings;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<CreateBookDto, Book>()
            .ForMember(dest => dest.IdBook, opt => opt.Ignore())
            .ForMember(dest => dest.AvgRating, opt => opt.Ignore())
            .ForMember(dest => dest.SoldQuantity, opt => opt.Ignore())
            .ForMember(dest => dest.Genres, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore())
            .ForMember(dest => dest.Reviews, opt => opt.Ignore())
            .ForMember(dest => dest.OrderDetails, opt => opt.Ignore())
            .ForMember(dest => dest.FavoriteBooks, opt => opt.Ignore())
            .ForMember(dest => dest.CartItems, opt => opt.Ignore());
    }
}
