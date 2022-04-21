
using IbrahimEyyupInan_Hafta2.Data;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Repository.Impl
{
    public class ProductRepository:BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(W2Context context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetByQueryAsync(ProductQuery query, List<Expression<Func<Product, object>>> includes=null)
        {
            IQueryable<Product> queryObj = generateQuery(query);
            if (includes != null) queryObj = includes.Aggregate(queryObj, (current, include) => current.Include(include));
            IEnumerable<Product> categories = await queryObj.Include(c => c.category).ToListAsync();

            return categories;
        }
        private IQueryable<Product> generateQuery(ProductQuery query)
        {
            // bu kod query oluşturmaktan sorumludur. Verilen query objesinin içerisindeki verilere göre IQueryable objesi oluşturulur
            IQueryable<Product> productContext = from s in _context.Product select s;
            if (query.Id != null)
            {
                productContext = productContext.Where(e => e.Id == query.Id);
            }
            if (query.Name != null)
            {
                productContext = productContext.Where(e => e.Name == query.Name);
            }
            if (query.sku != null)
            {
                productContext = productContext.Where(e => e.sku == query.sku);
            }
            if (query.categoryId != null)
            {
                productContext = productContext.Where(e => e.category.Id == query.categoryId);
            }
            if (query.categoryName != null)
            {
                productContext = productContext.Where(e => e.category.Name == query.categoryName);
            }
            if (query.priceStart != null)
            {
                if (query.priceEnd != null)
                {
                    productContext = productContext.Where(e => e.Price >= query.priceStart && e.Price <= query.priceEnd);
                }
                else if (query.priceStart < 0)
                {
                    productContext = productContext.Where(e => e.Price < query.priceStart * -1);
                }
                else
                {
                    productContext = productContext.Where(e => e.Price >= query.priceStart);
                }
            }

            return productContext;
        }
    }
}
