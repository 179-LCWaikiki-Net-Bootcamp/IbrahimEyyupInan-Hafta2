using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryViewModel>> getListAsync();

        public Task<CategoryViewModel> findByIdAsync(int id);


        public Task<CategoryViewModel> createAsync(CategoryDto productDto);
        public Task updateAsync(int id, CategoryDto productDto);
        public Task deleteAsync(int id);
        public Task<IEnumerable<CategoryViewModel>> getBySearchAsync(CategoryQuery query);
    }
}
