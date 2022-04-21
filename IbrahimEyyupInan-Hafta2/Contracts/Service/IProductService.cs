using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> getListAsync();

        public Task<ProductViewModel> findByIdAsync(int id);


        public Task<ProductViewModel> createAsync(ProductCreationDto productDto);
        public Task updateAsync(int id, ProductUpdationDto productDto);
        public Task deleteAsync(int id);
        public Task<IEnumerable<ProductViewModel>> getBySearchAsync(ProductQuery query);
    }
}
