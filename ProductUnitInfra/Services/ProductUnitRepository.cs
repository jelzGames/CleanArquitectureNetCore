using DatabaseMIgrations.Interfaces;
using DatabaseMIgrations.Services;
using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Models;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitInfra.Services
{
    public class ProductUnitRepository: IProductUnitRepository
    {
        private readonly IApplicationDbContext _db;

        public ProductUnitRepository(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseService<string>> Delete(string id)
        {
            try
            {
                var item = _db.ProductUnits.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    return new ResponseService<string>() { Message = "Not Found" };
                }

                _db.ProductUnits.Remove(item);
                await _db.SaveChangesAsync();

                return new ResponseService<string>() { Success = true };

            }
            catch (Exception ex)
            {
                return new ResponseService<string>() { Message = ex.Message };
            }
        }

        public async Task<ResponseService<ProductUnitModel>> Get(string id)
        {
            try
            {
                var item = _db.ProductUnits.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    return new ResponseService<ProductUnitModel>() { Message = "Not Found" };
                }

                return new ResponseService<ProductUnitModel>()
                {
                    Data = item,
                    Success = true 
                };

            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseService<ProductUnitModel>() { Message = ex.Message });
            }
        }

        public async Task<ResponseService<string>> Insert(ProductUnitModel model)
        {
            try
            {
                _db.ProductUnits.Add(model);
                await _db.SaveChangesAsync();

                return new ResponseService<string>() { Success = true };

            }
            catch (Exception ex)
            {
                return new ResponseService<string>() { Message = ex.Message };
            }
        }

        public async Task<ResponseService<IQueryable<ProductUnitModel>>> Query()
        {
            try
            {
                var items = _db.ProductUnits.Where(x => !string.IsNullOrEmpty(x.Id));
              
                return new ResponseService<IQueryable<ProductUnitModel>>()
                {
                    Data = items,
                    Success = true
                };

            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseService<IQueryable<ProductUnitModel>>() { Message = ex.Message });
            }
        }

        public async Task<ResponseService<string>> Update(ProductUnitModel model)
        {
            try
            {
                var item = _db.ProductUnits.FirstOrDefault(x => x.Id == model.Id);
                if (item == null)
                {
                    return new ResponseService<string>() { Message = "Not Found" };
                }

                item.Name = model.Name;
                await _db.SaveChangesAsync();

                return new ResponseService<string>() { Success = true };

            }
            catch (Exception ex)
            {
                return new ResponseService<string>() { Message = ex.Message };
            }
        }
    }
}
