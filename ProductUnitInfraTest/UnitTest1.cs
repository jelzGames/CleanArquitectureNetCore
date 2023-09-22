using DatabaseMIgrations.Interfaces;
using DatabaseMIgrations.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductUnitDomain.Models;
using ProductUnitInfra.Services;
using Shared.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Sockets;

namespace ProductUnitInfraTest
{
    public class Tests
    {
        private Mock<IApplicationDbContext> _dbContext;
        private Mock<DbSet<ProductUnitModel>> _dbSet;

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<IApplicationDbContext>();
            _dbSet = new Mock<DbSet<ProductUnitModel>>();
        }

       
        [Test]
        public async Task TestInsert()
        {
            _dbSet.Setup(dbSet => dbSet.Add(It.IsAny<ProductUnitModel>())).
                Callback<ProductUnitModel>((entity) => {
           
            });

            _dbContext.Setup(context => context.ProductUnits).Returns(_dbSet.Object);

            ProductUnitModel model = new ProductUnitModel();
            model.Id = "111";
            model.Name = "demo";

            var service = new ProductUnitRepository(_dbContext.Object);
            var result = await service.Insert(model);

            Assert.That(result.Success, "Insert failed");
        }

       [Test]
       public async Task TestUpdate()
       {
            var productUnits = new List<ProductUnitModel>
            {
                new ProductUnitModel { Id = "1", Name = "Product unit 1" },
                new ProductUnitModel { Id = "2", Name = "Product unit 2" },
            }.AsQueryable();

            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Provider).Returns(productUnits.Provider);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Expression).Returns(productUnits.Expression);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.ElementType).Returns(productUnits.ElementType);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.GetEnumerator()).Returns(() => productUnits.GetEnumerator());


            _dbContext.Setup(m => m.ProductUnits).Returns(_dbSet.Object);

           ProductUnitModel model = new ProductUnitModel();
           model.Id = "1";
           model.Name = "demo";

           var service = new ProductUnitRepository(_dbContext.Object);
           var result = await service.Update(model);

           Assert.That(result.Success, "Update failed");
       }
       
       [Test]
       public async Task TestDelete()
       {
            var productUnits = new List<ProductUnitModel>
            {
                new ProductUnitModel { Id = "1", Name = "Product unit 1" },
                new ProductUnitModel { Id = "2", Name = "Product unit 2" },
            }.AsQueryable();

            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Provider).Returns(productUnits.Provider);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Expression).Returns(productUnits.Expression);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.ElementType).Returns(productUnits.ElementType);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.GetEnumerator()).Returns(() => productUnits.GetEnumerator());

            _dbSet.Setup(m => m.Remove(It.IsAny<ProductUnitModel>()))
                .Callback<ProductUnitModel>((entity) =>
            {
            });

            _dbContext.Setup(m => m.ProductUnits).Returns(_dbSet.Object);

            var service = new ProductUnitRepository(_dbContext.Object);
           var result = await service.Delete("1");

           Assert.That(result.Success, "Delete failed");
       }

       [Test]
       public async Task TestGet()
       {
            var productUnits = new List<ProductUnitModel>
            {
                new ProductUnitModel { Id = "1", Name = "Product unit 1" },
                new ProductUnitModel { Id = "2", Name = "Product unit 2" },
            }.AsQueryable();

            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Provider).Returns(productUnits.Provider);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Expression).Returns(productUnits.Expression);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.ElementType).Returns(productUnits.ElementType);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.GetEnumerator()).Returns(() => productUnits.GetEnumerator());

            _dbContext.Setup(m => m.ProductUnits).Returns(_dbSet.Object);

            var service = new ProductUnitRepository(_dbContext.Object);
          
            var result = await service.Get("1");

           Assert.That(result.Success, "Get failed");
       }
       
        [Test]
        public async Task TestQuery()
        {
            var productUnits = new List<ProductUnitModel>
            {
                new ProductUnitModel { Id = "1", Name = "Product unit 1" },
                new ProductUnitModel { Id = "2", Name = "Product unit 2" },
            };

            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Provider)
                .Returns(productUnits.AsQueryable().Provider);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.Expression)
                .Returns(productUnits.AsQueryable().Expression);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.ElementType)
                .Returns(productUnits.AsQueryable().ElementType);
            _dbSet.As<IQueryable<ProductUnitModel>>()
                .Setup(m => m.GetEnumerator())
                .Returns(() => productUnits.GetEnumerator());

            _dbContext.Setup(m => m.ProductUnits).Returns(_dbSet.Object);
            
            var service = new ProductUnitRepository(_dbContext.Object);
            var result = await service.Query();

            Assert.That(result.Success, "Query failed");
        }
    }
}