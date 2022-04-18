using AutoMapper;
using IbrahimEyyupInan_Hafta2.Data;
using IbrahimEyyupInan_Hafta2.Exceptions;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public class ProductService:IProductService
    {
        private readonly W2Context _context;
        private readonly IMapper _mapper;
        public ProductService(W2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<ProductViewModel> getList()
        {
            //IEnumerable<Product> distinctContext = from s in _context.Product select s;
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_context.Product.Include(e=>e.category).ToList());
        }

        public async Task<IEnumerable<ProductViewModel>> getListAsync()
        {
            IEnumerable<Product> prods = await _context.Product.Include(e => e.category).ToListAsync();

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(prods);
        }

        public ProductViewModel findById(int id )
        {
            return _mapper.Map<Product, ProductViewModel>(_context.Product.Where(d => d.Id == id).Include(c => c.category)
                .FirstOrDefault());
        }
        public async Task<ProductViewModel> findByIdAsync(int id)
        {
           Product prod = await _context.Product.Where(d => d.Id == id).Include(c => c.category).FirstOrDefaultAsync();

            return _mapper.Map<Product, ProductViewModel>(prod);
        }


        public ProductViewModel create(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto,Product>(productDto);
            _context.Product.Add(product);
            _context.SaveChanges();
            return _mapper.Map<Product,ProductViewModel>(product);
        }
        public async Task<ProductViewModel> createAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<Product, ProductViewModel>(product);
        }

        public void update(int id,ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    throw new NotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task updateAsync(int id , ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
            Product product = _context.Product.Find(id);
            if (product == null)
            {
                throw  new NotFoundException();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            
        }
        public async Task deleteAsync(int id)
        {
            Product product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                throw new NotFoundException();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

    }
}
