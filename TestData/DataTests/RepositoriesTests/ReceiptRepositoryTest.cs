using Data.Entities;
using Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InternetAuction.Tests.DataTests.RepositoriesTests
{
    [TestFixture]
    public class ReceiptRepositoryTest
    {
        [Test]
        public async Task ReceiptRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Receipts.Add(new Receipt() { Id = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new ReceiptRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task ReceiptRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            var repository = new ReceiptRepository(dbContext);

            await repository.AddAsync(new Receipt() { Id = 1 });
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.Receipts.Count());
        }

        [Test]
        public void ReceiptRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new ReceiptRepository(dbContext);
            Receipt entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task ReceiptRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Receipts.AddRange(
                new Receipt() { Id = 1 },
                new Receipt() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new ReceiptRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.Receipts.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.Receipts.First().Id, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task ReceiptRepository_GetByIdAsync_ReturnsEntityById()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Receipts.AddRange(
                new Receipt() { Id = 1 },
                new Receipt() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new ReceiptRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.Id);
        }

        [Test]
        public async Task ReceiptRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();

            var repository = new ReceiptRepository(dbContext);

            var entity = new Receipt() { Id = 2, Cost = 43, CustomerId = 44, LotId = 45 };

            repository.Update(entity);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(43, dbContext.Receipts.Find(2).Cost);
            Assert.AreEqual(44, dbContext.Receipts.Find(2).CustomerId);
            Assert.AreEqual(45, dbContext.Receipts.Find(2).LotId);
        }
        [Test]
        public void ReceiptRepository_Update_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new ReceiptRepository(dbContext);
            Receipt entity = null;

            void actualy() => repository.Update(entity);

            Assert.Throws<ArgumentNullException>(actualy);
        }
    }
}
