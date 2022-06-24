﻿using System;
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
    public class LotRepositoryTest
    {
        [Test]
        public async Task LotRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Lots.Add(new Lot() { Id = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new LotRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task LotRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            var repository = new LotRepository(dbContext);

            await repository.AddAsync(new Lot() { Id = 1 });
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.Lots.Count());
        }

        [Test]
        public void LotRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotRepository(dbContext);
            Lot entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task LotRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Lots.AddRange(
                new Lot() { Id = 1 },
                new Lot() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new LotRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.Lots.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.Lots.First().Id, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task LotRepository_GetByIdAsync_ReturnsValue()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Lots.AddRange(
                new Lot() { Id = 1 },
                new Lot() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new LotRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.Id);
        }

        [Test]
        public async Task LotRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();

            var repository = new LotRepository(dbContext);

            var entity = new Lot() { Id = 2, Name = "new Name", CategoryId = 11, Description = "new description", InitialPrice = 1234 };

            repository.Update(entity);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual("new Name", dbContext.Lots.Find(2).Name);
            Assert.AreEqual(11, dbContext.Lots.Find(2).CategoryId);
            Assert.AreEqual("new description", dbContext.Lots.Find(2).Description);
            Assert.AreEqual(1234, dbContext.Lots.Find(2).InitialPrice);
        }
        [Test]
        public void LotRepository_Update_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotRepository(dbContext);
            Lot entity = null;

            void actualy() => repository.Update(entity);

            Assert.Throws<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task LotRepository_GetAllByDetalsAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Lots.Add(new Lot()
            {
                Id = 1,
                Name = "Test",
                CategoryId = 1,
                OwnerId = 1,
                LotImages = new LotImage[] { new LotImage() },
                Category = new LotCategory(),
            }
            );
            await dbContext.SaveChangesAsync();

            var repository = new LotRepository(dbContext);

            var actualy = await repository.GetAllByDetalsAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task LotRepository_GetAllByDetalsByCategoryIdAsync_ReturnsValuesFromCategory()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotRepository(dbContext);

            var actualy = await repository.GetAllByDetalsByCategoryIdAsync(categoryId: 2);

            Assert.AreEqual(2, actualy.Count());
        }

        [Test]
        public async Task LotRepository_GetByIdWithDetailsAsync_ReturnsValuesFromCategory()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new LotRepository(dbContext);

            var actualy = await repository.GetByIdWithDetailsAsync(1);

            Assert.That(actualy.Id == 1, "Returns invalid id");
            Assert.That(actualy.Category != null, "Returns invalid Category");
            Assert.That(actualy.Receipt != null, "Returns invalid Receipt");
            Assert.That(actualy.LotImages.Any, "Returns invalid LotImages");
        }

        [Test]
        public async Task LotRepository_GetIdAsync_ReturnsValue()
        {
            var lot = GetLot();
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            await dbContext.Lots.AddRangeAsync(lot);
            await dbContext.SaveChangesAsync();
            var repository = new LotRepository(dbContext);

            var lot0 = GetLot();
            lot0.Id = 0;
            var actualy = await repository.GetIdAsync(lot);

            Assert.AreEqual(12, actualy.First().Id);
        }

        private Lot GetLot()
        {
            return new Lot()
            {
                Id = 12,
                Name = "name1",
                CategoryId = 5,
                Deadline = DateTime.Now,
                Description = "ass",
                InitialPrice = 20,
                OwnerId = 11
            };
        }

    }
}
