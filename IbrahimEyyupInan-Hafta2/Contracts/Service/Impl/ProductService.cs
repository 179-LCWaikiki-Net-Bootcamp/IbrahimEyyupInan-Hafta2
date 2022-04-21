using AutoMapper;
using IbrahimEyyupInan_Hafta2.Contracts.Repository;
using IbrahimEyyupInan_Hafta2.Data;
using IbrahimEyyupInan_Hafta2.Exceptions;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Model.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        // buradaki includes category id ve category name değerlerini çekebilmek için category objesini 
        // çekilen dataya dahil etmek için generic koda parametre olarak veriliyor.
        private List<Expression<Func<Product, object>>> includes = new List<Expression<Func<Product, object>>>()
            {
                (e=>e.category)
            };
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductViewModel>> getListAsync()
        {
            IEnumerable<Product> product = await _repo.GetAllAsync(includes);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(product);
        }


        public async Task<IEnumerable<ProductViewModel>> getBySearchAsync(ProductQuery query)
        {
            IEnumerable<Product> prods = await _repo.GetByQueryAsync(query, includes);

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(prods);
        }
        public async Task<ProductViewModel> findByIdAsync(int id)
        {
           Product prod = await _repo.GetByIdAsync(id, includes);

            return _mapper.Map<Product, ProductViewModel>(prod);
        }



        public async Task<ProductViewModel> createAsync(ProductCreationDto productDto)
        {
            // product map ile dönüştürülüp kaydediliyor. Daha sonrasında ViewModel'e dönüştürülüp cevap olarak gönderilmek üzere
            // return ediliyor.
            Product product = _mapper.Map<ProductCreationDto, Product>(productDto);
            await _repo.AddAsync(product);
            return _mapper.Map<Product, ProductViewModel>(product);
        }



        public async Task updateAsync(int id , ProductUpdationDto productDto)
        {
            // verilen id ile ilgili bir product bulunuyor mu diye kontrol ediyor. Eğer bulunamazsa zaten NotFound Exception'u üretiliyor
            // ve en yukarıdaki fonksiyon bu exception'u yakalayıp notFound cevabu dönüyor.
            // burada var olan datayı çekmemizin nedeni autoMapper'ın gelen data'daki null verilerin yerine bize var olan 
            // verileri vermesini sağlamak
            Product existingProd = await _repo.GetByIdAsync(id,includes);
            Product product = _mapper.Map(productDto, existingProd);
            await _repo.UpdateAsync(product);
             
        }

        public async Task deleteAsync(int id)
        {
            Product product = await _repo.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException();
            }
            await _repo.DeleteAsync(product);
        }

    }
}
