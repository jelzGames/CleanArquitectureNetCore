using ProductUnitDomain.Models;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitDomain.Interfaces
{
    public interface IProductUnitRepository
    {
        Task<ResponseService<string>> Insert(ProductUnitModel model);
        Task<ResponseService<string>> Update(ProductUnitModel model);
        Task<ResponseService<string>> Delete(string id);
        Task<ResponseService<ProductUnitModel>> Get(string id);
        Task<ResponseService<IQueryable<ProductUnitModel>>> Query();
    }
}
