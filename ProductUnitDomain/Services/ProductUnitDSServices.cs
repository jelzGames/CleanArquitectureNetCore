using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Models;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitDomain.Services
{
    public class ProductUnitDSServices: IProductUnitDSServices
    {
        private readonly IProductUnitRepository _repository;

        public ProductUnitDSServices(IProductUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseService<string>> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ResponseService<ProductUnitModel>> Get(string id)
        {
            return await _repository.Get(id);
        }

        public async Task<ResponseService<string>> Insert(ProductUnitModel model)
        {
            return await _repository.Insert(model);
        }

        public async Task<ResponseService<IQueryable<ProductUnitModel>>> Query()
        {
            return await _repository.Query();
        }

        public async Task<ResponseService<string>> Update(ProductUnitModel model)
        {
            return await _repository.Update(model);
        }
    }
}
