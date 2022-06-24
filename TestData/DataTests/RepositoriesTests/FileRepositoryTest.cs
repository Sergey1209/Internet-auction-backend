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
    public class FileRepositoryTest
    {
        [Test]
        public async Task FileRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Files.Add(new File() { Id = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new FileRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task FileRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            var repository = new FileRepository(dbContext);

            await repository.AddAsync(new File() { Id = 1 });
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.Files.Count());
        }

        [Test]
        public void FileRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new FileRepository(dbContext);
            File entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task FileRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Files.AddRange(
                new File() { Id = 1 },
                new File() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new FileRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.Files.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.Files.First().Id, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task FileRepository_GetByIdAsync_ReturnsEntityById()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextTest();
            dbContext.Files.AddRange(
                new File() { Id = 1 },
                new File() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new FileRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.Id);
        }

        [Test]
        public async Task FileRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new FileRepository(dbContext);

            var entity = new File() { Id = 2, Name = "new Name1" };

            repository.Update(entity);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual("new Name1", dbContext.Files.Find(2).Name);
        }
        [Test]
        public void FileRepository_Update_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            var repository = new FileRepository(dbContext);
            File entity = null;

            void actualy() => repository.Update(entity);

            Assert.Throws<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task FileRepository_GetIdByNameAsync_ReturnsIdByName()
        {
            var dbContext = UnitTestHelper.CreateInternetAuctionDbContextWhitDataTest();
            await dbContext.SaveChangesAsync();

            var repository = new FileRepository(dbContext);

            var actual = await repository.GetIdByNameAsync("filename3");

            Assert.AreEqual(3, actual);
        }
    }
}
