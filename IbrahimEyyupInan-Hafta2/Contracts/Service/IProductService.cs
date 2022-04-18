using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public interface IProductService:IBaseService<Product,ProductViewModel,ProductDto>
    {
        public IEnumerable<ProductViewModel> getBySearch(ProductQuery query);
        public Task<IEnumerable<ProductViewModel>> getBySearchAsync(ProductQuery query);
    }
}
