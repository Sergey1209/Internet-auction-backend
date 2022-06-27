using Data.Entities;
using Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InternetAuction.Tests.DataTests.RepositoriesTests
{
    [TestFixture]
    public class PersonRepositoryTest
    {
        [Test]
        public async Task PersonRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            dbContext.People.Add(new Person() { Id = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new PersonRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task PersonRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            var repository = new PersonRepository(dbContext);

            await repository.AddAsync(new Person() { Id = 1 });
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.People.Count());
        }

        [Test]
        public void PersonRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextWhitDataTest();
            var repository = new PersonRepository(dbContext);
            Person entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task PersonRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            dbContext.People.AddRange(
                new Person() { Id = 1 },
                new Person() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new PersonRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.People.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.People.First().Id, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task PersonRepository_GetByIdAsync_ReturnsEntityById()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            dbContext.People.AddRange(
                new Person() { Id = 1 },
                new Person() { Id = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new PersonRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.Id);
        }

        [Test]
        public async Task PersonRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextWhitDataTest();

            var repository = new PersonRepository(dbContext);

            var entity = new Person() { Id = 2, Nickname = "new Name" };

            repository.Update(entity);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual("new Name", dbContext.People.Find(2).Nickname);
        }
        [Test]
        public void PersonRepository_Update_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextWhitDataTest();
            var repository = new PersonRepository(dbContext);
            Person entity = null;

            void actualy() => repository.Update(entity);

            Assert.Throws<ArgumentNullException>(actualy);
        }
    }
}
