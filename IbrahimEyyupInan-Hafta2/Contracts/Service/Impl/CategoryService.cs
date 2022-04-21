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
            // product map ile dönüştürülüp kaydediliyor. Daha sonrasında ViewModel'e dönüştürülüp cevap olarak gönderilmek üzere
            // return ediliyor.
            Category Category = _mapper.Map<CategoryDto, Category>(CategoryDto);
            await _repo.AddAsync(Category);

            return _mapper.Map<Category, CategoryViewModel>(Category);
        }



        public async Task updateAsync(int id, CategoryDto CategoryDto)
        {
            // verilen id ile ilgili bir product bulunuyor mu diye kontrol ediyor. Eğer bulunamazsa zaten NotFound Exception'u üretiliyor
            // ve en yukarıdaki fonksiyon bu exception'u yakalayıp notFound cevabu dönüyor.
            // burada var olan datayı çekmemizin nedeni autoMapper'ın gelen data'daki null verilerin yerine bize var olan 
            // verileri vermesini sağlamak
            Category ExistingCategory = await _repo.GetByIdAsync(id);

            Category Category = _mapper.Map(CategoryDto, ExistingCategory);
            
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
