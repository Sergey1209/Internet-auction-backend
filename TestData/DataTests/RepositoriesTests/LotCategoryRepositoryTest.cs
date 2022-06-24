using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Data.Entities;
using Data.Repositories;
using Data.Validation;
using NUnit.Framework;

namespace InternetAuction.Tests.DataTests.RepositoriesTests
{
    [TestFixture]
    public class LotCategoryRepositoryTest
    {
        [Test]
        public async Task LotCategoryRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.LotCategories.Add(new LotCategory() { Id = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new LotCategoryRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task LotCategoryRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            var repository = new LotCategoryRepository(dbContext);

            await repository.AddAsync(new LotCategory() { Id = 1});
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.LotCategories.Count());
        }

        [Test]
        public void LotCategoryRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotCategoryRepository(dbContext);
            LotCategory entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task LotCategoryRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.LotCategories.AddRange(
                new LotCategory() { Id = 1 },
                new LotCategory() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new LotCategoryRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.LotCategories.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.LotCategories.First().Id, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task LotCategoryRepository_GetByIdAsync_ReturnsEntityById()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.LotCategories.AddRange(
                new LotCategory() { Id = 1 },
                new LotCategory() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new LotCategoryRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.Id);
        }

        [Test]
        public async Task LotCategoryRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();

            var repository = new LotCategoryRepository(dbContext);

            var entity = new LotCategory() { Id = 2, Name = "new Name1" };

            repository.Update(entity);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual("new Name1", dbContext.LotCategories.Find(2).Name);
        }
        [Test]
        public void LotCategoryRepository_Update_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotCategoryRepository(dbContext);
            LotCategory entity = null;

            void actualy() => repository.Update(entity);

            Assert.Throws<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task LotCategoryRepository_GetAllByDetalsAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.LotCategories.Add(new LotCategory() { Id = 1, File = new File(), Lots = new Lot[] { } });
            await dbContext.SaveChangesAsync();

            var repository = new LotCategoryRepository(dbContext);

            var actualy = await repository.GetAllByDetalsAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task LotCategoryRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetals()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotCategoryRepository(dbContext);

            var actualy = await repository.GetByIdWithDetailsAsync(2);

            Assert.That(actualy.Id == 2, "Returns invalid id");
            Assert.That(actualy.File.Name == "filename2", "Returns invalid File.Name");
            Assert.That(actualy.Lots.First().Id == 1, "Returns invalid Lots.First.Id");
        }

    }
}
