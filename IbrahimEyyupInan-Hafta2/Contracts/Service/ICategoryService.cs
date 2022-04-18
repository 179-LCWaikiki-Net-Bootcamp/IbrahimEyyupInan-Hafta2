using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public interface ICategoryService: IBaseService<Category, CategoryViewModel, CategoryDto>
    {
        public Task<IEnumerable<CategoryViewModel>> getBySearchAsync(CategoryQuery query);
    }
}
