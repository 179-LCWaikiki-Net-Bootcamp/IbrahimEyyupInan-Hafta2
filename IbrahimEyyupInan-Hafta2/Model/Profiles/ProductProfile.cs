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
            CreateMap<ProductCreationDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
            CreateMap<ProductUpdationDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));



        }
    }
}
