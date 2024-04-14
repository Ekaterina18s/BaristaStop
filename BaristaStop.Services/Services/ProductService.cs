using AutoMapper;
using BaristaStop.Data.Data;
using BaristaStop.Data.Repositories.Abstractions;
using BaristaStop.Services.DTOs;
using BaristaStop.Services.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaStop.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateProductAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _repository.AddAsync(productEntity);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _repository.DeleteByIdAsync(productId);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            return _mapper.Map<ProductDTO>(await _repository.GetByIdAsync(productId));
        }

        public async Task UpdateProductAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _repository.UpdateAsync(productEntity);
        }
    }
}

