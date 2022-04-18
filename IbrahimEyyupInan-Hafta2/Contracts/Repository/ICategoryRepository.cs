using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Repository
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        public Task<IEnumerable<Category>> GetByQueryAsync(CategoryQuery query);
    }
}
