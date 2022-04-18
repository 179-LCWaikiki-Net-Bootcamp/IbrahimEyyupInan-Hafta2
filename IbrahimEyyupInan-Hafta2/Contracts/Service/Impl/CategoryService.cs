using AutoMapper;
using IbrahimEyyupInan_Hafta2.Data;
using IbrahimEyyupInan_Hafta2.Exceptions;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Model.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly W2Context _context;
        private readonly IMapper _mapper;
        public CategoryService(W2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<CategoryViewModel> getList()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_context.Category.ToList());
        }

        public async Task<IEnumerable<CategoryViewModel>> getListAsync()
        {
            IEnumerable<Category> prods = await _context.Category.ToListAsync();

            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(prods);
        }

        public IEnumerable<CategoryViewModel> getBySearch(CategoryQuery query)
        {
            IQueryable<Category> queryObj = generateQuery(query);
            IEnumerable<Category> categories = queryObj.ToList();

            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
        }

        public async Task<IEnumerable<CategoryViewModel>> getBySearchAsync(CategoryQuery query)
        {
            IQueryable<Category> queryObj = generateQuery(query);
            IEnumerable < Category > categories =await queryObj.ToListAsync();

            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
        }



        public CategoryViewModel findById(int id)
        {
            return _mapper.Map<Category, CategoryViewModel>(_context.Category.Find(id));
        }
        public async Task<CategoryViewModel> findByIdAsync(int id)
        {
            Category prod = await _context.Category.FindAsync(id);

            return _mapper.Map<Category, CategoryViewModel>(prod);
        }


        public CategoryViewModel create(CategoryDto CategoryDto)
        {
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            _context.Category.Add(Category);
            _context.SaveChanges();
            return _mapper.Map<Category, CategoryViewModel>(Category);
        }
        public async Task<CategoryViewModel> createAsync(CategoryDto CategoryDto)
        {
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            await _context.Category.AddAsync(Category);
            await _context.SaveChangesAsync();
            return _mapper.Map<Category, CategoryViewModel>(Category);
        }

        public void update(int id, CategoryDto CategoryDto)
        {
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            _context.Entry(Category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    throw new NotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task updateAsync(int id, CategoryDto CategoryDto)
        {
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            _context.Entry(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    throw new NotFoundException();
                }
                else
                {
                    throw;
                }
            }

        }
        public void delete(int id)
        {
            Category Category = _context.Category.Find(id);
            if (Category == null)
            {
                throw new NotFoundException();
            }

            _context.Category.Remove(Category);
            _context.SaveChanges();


        }
        public async Task deleteAsync(int id)
        {
            Category Category = await _context.Category.FindAsync(id);
            if (Category == null)
            {
                throw new NotFoundException();
            }

            _context.Category.Remove(Category);
            await _context.SaveChangesAsync();
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
        private IQueryable<Category> generateQuery(CategoryQuery query)
        {
            IQueryable<Category> categoryContext = from s in _context.Category select s;
            if (query.Id != null)
            {
                categoryContext= categoryContext.Where(e=>e.Id==query.Id);
            }
            if(query.Name != null)
            {
                categoryContext = categoryContext.Where(e => e.Name == query.Name);
            }

            return categoryContext;
        }
    }
}
