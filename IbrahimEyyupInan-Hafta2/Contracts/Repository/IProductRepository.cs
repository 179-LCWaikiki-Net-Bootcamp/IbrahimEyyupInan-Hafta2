using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<IEnumerable<Product>> GetByQueryAsync(ProductQuery query, List<Expression<Func<Product, object>>> includes = null);

    }
}
