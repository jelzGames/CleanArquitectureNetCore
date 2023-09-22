using ProductUnitAplication.Dtos;
using ProductUnitDomain.Models;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitAplication.Interfaces
{
    public interface IProductUnitAppServices
    {
        Task<ResponseService<string>> Insert(ProductUnitDto model);
        Task<ResponseService<string>> Update(ProductUnitDto model);
        Task<ResponseService<string>> Delete(string id);
        Task<ResponseService<ProductUnitDto>> Get(string id);
        Task<ResponseService<List<ProductUnitDto>>> Query();
    }
}
