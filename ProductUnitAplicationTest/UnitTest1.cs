using Moq;
using ProductUnitAplication.Dtos;
using ProductUnitAplication.Interfaces;
using ProductUnitAplication.Services;
using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Models;
using Shared.Services;

namespace ProductUnitAplicationTest
{
    public class Tests
    {
        private Mock<IProductUnitDSServices> _services;

        [SetUp]
        public void Setup()
        {
            _services = new Mock<IProductUnitDSServices>();
        }

        [Test]
        public async Task TestInsert()
        {
            _services.Setup(s => s.Insert(It.IsAny<ProductUnitModel>()))
                .ReturnsAsync(new ResponseService<string>() { Success = true });

            ProductUnitDto dto = new ProductUnitDto();
            dto.Id = "111";
            dto.Name = "demo";

            var service = new ProductUnitAppServices(_services.Object);
            var result = await service.Insert(dto);

            Assert.That(result.Success, "Insert failed");
        }

        [Test]
        public async Task TestUpdate()
        {
            _services.Setup(s => s.Update(It.IsAny<ProductUnitModel>()))
                .ReturnsAsync(new ResponseService<string>() { Success = true });

            ProductUnitDto dto = new ProductUnitDto();
            dto.Id = "111";
            dto.Name = "demo";

            var service = new ProductUnitAppServices(_services.Object);
            var result = await service.Update(dto);

            Assert.That(result.Success, "Update failed");
        }

        [Test]
        public async Task TestDelete()
        {
            _services.Setup(s => s.Delete(It.IsAny<string>()))
                .ReturnsAsync(new ResponseService<string>() { Success = true });

            var service = new ProductUnitAppServices(_services.Object);
            var result = await service.Delete("111");

            Assert.That(result.Success, "Delete failed");
        }

        [Test]
        public async Task TestGet()
        {
            _services.Setup(s => s.Get(It.IsAny<string>()))
                .ReturnsAsync(new ResponseService<ProductUnitModel>() {
                    Data = new ProductUnitModel(),
                    Success = true
                });

            var service = new ProductUnitAppServices(_services.Object);
            var result = await service.Get("111");

            Assert.That(result.Success, "Get failed");
        }
        [Test]
        public async Task TestQuery()
        {
            _services.Setup(s => s.Query())
                .ReturnsAsync(
                    new ResponseService<IQueryable<ProductUnitModel>>() 
                    { 
                        Data = new List<ProductUnitModel>().AsQueryable(),
                        Success = true 
                    }
                );

            var service = new ProductUnitAppServices(_services.Object);
            var result = await service.Query();

            Assert.That(result.Success, "Query failed");
        }

    }
}