using Data.Entities;
using Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InternetAuction.Tests.DataTests.RepositoriesTests
{
    [TestFixture]
    public class AuctionRepositoryTest
    {
        [Test]
        public async Task AuctionRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Auctions.Add(new Auction() { Id = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new AuctionRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task AuctionRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            var repository = new AuctionRepository(dbContext);

            await repository.AddAsync(new Auction() { Id = 1 });
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.Auctions.Count());
        }

        [Test]
        public void AuctionRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new AuctionRepository(dbContext);
            Auction entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task AuctionRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Auctions.AddRange(
                new Auction() { Id = 1 },
                new Auction() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new AuctionRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.Auctions.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.Auctions.First().Id, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task AuctionRepository_GetByIdAsync_ReturnsEntityById()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Auctions.AddRange(
                new Auction() { Id = 1 },
                new Auction() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new AuctionRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.Id);
        }

        [Test]
        public async Task AuctionRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new AuctionRepository(dbContext);

            var auction = new Auction() { Id = 2, BetValue = 43, CustomerId = 44 };

            repository.Update(auction);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(43, dbContext.Auctions.Find(2).BetValue);
            Assert.AreEqual(44, dbContext.Auctions.Find(2).CustomerId);
            Assert.AreEqual(new DateTime(year: 2023, month: 2, day: 13), dbContext.Auctions.Find(2).Deadline);
            Assert.AreEqual(12, dbContext.Auctions.Find(2).InitialPrice);
            Assert.AreEqual(2, dbContext.Auctions.Find(2).LotId);
        }

        [Test]
        public void AuctionRepository_Update_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new AuctionRepository(dbContext);
            Auction entity = null;

            void actualy() => repository.Update(entity);

            Assert.Throws<ArgumentNullException>(actualy);
        }
    }
}
