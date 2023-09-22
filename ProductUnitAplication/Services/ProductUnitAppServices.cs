using ProductUnitAplication.Dtos;
using ProductUnitAplication.Interfaces;
using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Models;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitAplication.Services
{
    public class ProductUnitAppServices : IProductUnitAppServices
    {
        private readonly IProductUnitDSServices _services;

        public ProductUnitAppServices(IProductUnitDSServices services)
        {
            _services = services;
        }


        public async Task<ResponseService<string>> Delete(string id)
        {
            return await _services.Delete(id);
        }

        public async Task<ResponseService<ProductUnitDto>> Get(string id)
        {
            var result = await _services.Get(id);
            if (result.Success)
            {
                ProductUnitDto dto = new ProductUnitDto();
                dto.Id = result.Data.Id;
                dto.Name = result.Data.Name;

                return new ResponseService<ProductUnitDto>()
                {
                    Data = dto,
                    Success = true
                };
            }

            return new ResponseService<ProductUnitDto>()
            {
                Message = result.Message,
                Success = true
            };
        }

        public async Task<ResponseService<string>> Insert(ProductUnitDto dto)
        {
            ProductUnitModel model = new ProductUnitModel();
            model.Id = dto.Id;
            model.Name = dto.Name;
     
            return await  _services.Insert(model);
        }

        public async Task<ResponseService<List<ProductUnitDto>>> Query()
        {
            var result = await _services.Query();
            if (result.Success)
            {
                List<ProductUnitDto> dtos = new List<ProductUnitDto>();
                foreach (var item in result.Data)
                {
                    ProductUnitDto dto = new ProductUnitDto();
                    dto.Id = item.Id;
                    dto.Name = item.Name;
                    dtos.Add(dto);
                }

                return new ResponseService<List<ProductUnitDto>>()
                {
                    Data = dtos,
                    Success = true
                };
            }

            return new ResponseService<List<ProductUnitDto>>()
            {
                Message = result.Message,
                Success = true
            };
        }

        public async Task<ResponseService<string>> Update(ProductUnitDto dto)
        {

            ProductUnitModel model = new ProductUnitModel();
            model.Id = dto.Id;
            model.Name = dto.Name;

            return await _services.Update(model);
        }
    }
}
