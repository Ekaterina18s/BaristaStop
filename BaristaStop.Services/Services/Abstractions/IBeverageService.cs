using BaristaStop.Data.Data;
using BaristaStop.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaStop.Services.Services.Abstractions
{
    public interface IBeverageService
    {
        Task<IEnumerable<BeverageDTO>> GetAllBeveragesAsync();
        Task<IEnumerable<BeverageDTO>> GetAllBeveragesByProductIdAsync(int productId);
        Task<BeverageDTO> GetBeverageByIdAsync(int beverageId);
        Task CreateBeverageAsync(BeverageDTO beverage);
        Task UpdateBeverageAsync(BeverageDTO beverage);
        Task DeleteBeverageAsync(int beverageId);
    }
}
