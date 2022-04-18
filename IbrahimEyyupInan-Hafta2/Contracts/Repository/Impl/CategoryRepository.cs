using IbrahimEyyupInan_Hafta2.Contracts.Repository.Impl;
using IbrahimEyyupInan_Hafta2.Data;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Repository
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(W2Context dbContext) : base(dbContext)
        {
        }
         public async Task<IEnumerable<Category>> GetByQueryAsync(CategoryQuery query)
        {
            IQueryable<Category> queryObj = generateQuery(query);
            IEnumerable<Category> categories = await queryObj.ToListAsync();

            return categories;
        }
        private IQueryable<Category> generateQuery(CategoryQuery query)
        {
            IQueryable<Category> categoryContext = from s in _context.Category select s;
            if (query.Id != null)
            {
                categoryContext = categoryContext.Where(e => e.Id == query.Id);
            }
            if (query.Name != null)
            {
                categoryContext = categoryContext.Where(e => e.Name == query.Name);
            }

            return categoryContext;
        }
    }
}
