using Moq;
using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Models;
using ProductUnitDomain.Services;
using Shared.Services;

namespace ProductUnitDomainTest
{
    public class Tests
    {
        private Mock<IProductUnitRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IProductUnitRepository>();
        }

        [Test]
        public async Task TestInsert()
        {
            _repository.Setup(s => s.Insert(It.IsAny<ProductUnitModel>()))
                .ReturnsAsync(new ResponseService<string>() { Success = true });

            ProductUnitModel model = new ProductUnitModel();
            model.Id = "111";
            model.Name = "demo";

            var service = new ProductUnitDSServices(_repository.Object);
            var result = await service.Insert(model);

            Assert.That(result.Success, "Insert failed");
        }

        [Test]
        public async Task TestUpdate()
        {
            _repository.Setup(s => s.Update(It.IsAny<ProductUnitModel>()))
                .ReturnsAsync(new ResponseService<string>() { Success = true });


            ProductUnitModel model = new ProductUnitModel();
            model.Id = "111";
            model.Name = "demo";

            var service = new ProductUnitDSServices(_repository.Object);
            var result = await service.Update(model);

            Assert.That(result.Success, "Update failed");
        }

        [Test]
        public async Task TestDelete()
        {
            _repository.Setup(s => s.Delete(It.IsAny<string>()))
                .ReturnsAsync(new ResponseService<string>() { Success = true });

            var service = new ProductUnitDSServices(_repository.Object);
            var result = await service.Delete("111");

            Assert.That(result.Success, "Delete failed");
        }

        [Test]
        public async Task TestGet()
        {
            _repository.Setup(s => s.Get(It.IsAny<string>()))
                .ReturnsAsync(new ResponseService<ProductUnitModel>()
                {
                    Data = new ProductUnitModel(),
                    Success = true
                });

            var service = new ProductUnitDSServices(_repository.Object);
            var result = await service.Get("111");

            Assert.That(result.Success, "Get failed");
        }
        [Test]
        public async Task TestQuery()
        {
            _repository.Setup(s => s.Query())
                .ReturnsAsync(
                    new ResponseService<IQueryable<ProductUnitModel>>()
                    {
                        Data = new List<ProductUnitModel>().AsQueryable(),
                        Success = true
                    }
                );

            var service = new ProductUnitDSServices(_repository.Object);
            var result = await service.Query();

            Assert.That(result.Success, "Query failed");
        }
    }

}
