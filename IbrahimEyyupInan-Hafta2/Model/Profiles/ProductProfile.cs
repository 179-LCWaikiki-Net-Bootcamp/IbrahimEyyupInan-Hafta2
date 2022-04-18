using AutoMapper;
using IbrahimEyyupInan_Hafta2.Model.Dto;

namespace IbrahimEyyupInan_Hafta2.Model.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.categoryName,
                    opt => opt.MapFrom(src => src.category.Name)
                ); ;

            CreateMap<ProductViewModel, Product>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

        }
    }
}
