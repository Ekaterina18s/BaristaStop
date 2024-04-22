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
    public class BeverageService : IBeverageService
    {
        private readonly IRepository<Beverage> _repository;
        private readonly IMapper _mapper;

        public BeverageService(IRepository<Beverage> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task CreateBeverageAsync(BeverageDTO beverage)
        {
            var beverageEntity = _mapper.Map<Beverage>(beverage);
            await _repository.AddAsync(beverageEntity);
        }

        public Task DeleteBeverageAsync(int beverageId)
        {
            await _repository.DeleteByIdAsync(beverageId);
        }

        public Task<IEnumerable<BeverageDTO>> GetAllBeveragesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BeverageDTO>> GetAllBeveragesByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<BeverageDTO> GetBeverageByIdAsync(int beverageId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBeverageAsync(BeverageDTO beverage)
        {
            throw new NotImplementedException();
        }
    }
}
