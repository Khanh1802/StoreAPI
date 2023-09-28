using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(dest => dest.Brand, otp => otp.MapFrom(src => src.Product.Brand))
                .ForMember(dest => dest.Name, otp => otp.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.PictureUrl, otp => otp.MapFrom(src  => src.Product.PictureUrl))
                .ForMember(dest => dest.Price, otp => otp.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Type, otp => otp.MapFrom(src => src.Product.Type));
        }
    }
}
