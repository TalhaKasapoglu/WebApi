using AutoMapper;
using WebAPI.DTOs.FeatureDTO;
using WebAPI.DTOs.MessageDTO;
using WebAPI.DTOs.ProductDTO;
using WebAPI.Entities;

namespace WebAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();

            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, GetByIdMessageDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ForMember(p => p.CategoryName, x => x.MapFrom(y => y.Category.CategoryName)).ReverseMap();
        }
    }
}
