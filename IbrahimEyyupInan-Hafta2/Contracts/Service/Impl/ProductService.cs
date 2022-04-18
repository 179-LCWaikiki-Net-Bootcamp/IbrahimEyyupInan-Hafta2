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



        public async Task<ProductViewModel> createAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            await _repo.AddAsync(product);
            return _mapper.Map<Product, ProductViewModel>(product);
        }



        public async Task updateAsync(int id , ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
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
