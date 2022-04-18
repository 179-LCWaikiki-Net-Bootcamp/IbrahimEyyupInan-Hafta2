using AutoMapper;
using IbrahimEyyupInan_Hafta2.Model.Dto;

namespace IbrahimEyyupInan_Hafta2.Model.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
