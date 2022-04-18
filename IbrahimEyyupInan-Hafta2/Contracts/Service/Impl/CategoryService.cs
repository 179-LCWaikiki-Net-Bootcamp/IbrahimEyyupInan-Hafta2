using AutoMapper;
using IbrahimEyyupInan_Hafta2.Contracts.Repository;
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
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CategoryViewModel>> getListAsync()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(await _repo.GetAllAsync());
        }



        public async Task<IEnumerable<CategoryViewModel>> getBySearchAsync(CategoryQuery query)
        {
            IEnumerable<Category> categories =await  _repo.GetByQueryAsync(query);

            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
        }

   
        public async Task<CategoryViewModel> findByIdAsync(int id)
        {
            return _mapper.Map<Category, CategoryViewModel>(await _repo.GetByIdAsync(id));
        }


        public async Task<CategoryViewModel> createAsync(CategoryDto CategoryDto)
        {
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            await _repo.AddAsync(Category);

            return _mapper.Map<Category, CategoryViewModel>(Category);
        }



        public async Task updateAsync(int id, CategoryDto CategoryDto)
        {
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            await _repo.UpdateAsync(Category);

        }
        public async Task deleteAsync(int id)
        {
            
            Category category = await _repo.GetByIdAsync(id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            await _repo.DeleteAsync(category);
        }

    }
}
