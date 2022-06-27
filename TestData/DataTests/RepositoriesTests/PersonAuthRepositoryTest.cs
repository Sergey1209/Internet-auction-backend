using Data.Entities;
using Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InternetAuction.Tests.DataTests.RepositoriesTests
{
    [TestFixture]
    public class PersonAuthRepositoryTest
    {
        [Test]
        public async Task PersonAuthRepository_GetAllAsync_ReturnsAllValues()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            dbContext.PeopleAuths.Add(new PersonAuth() { PersonId = 1 });
            await dbContext.SaveChangesAsync();

            var repository = new PersonAuthRepository(dbContext);

            var actualy = await repository.GetAllAsync();

            Assert.AreEqual(1, actualy.Count());
        }

        [Test]
        public async Task PersonAuthRepository_AddAsync_AddsValueToDataBase()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            var repository = new PersonAuthRepository(dbContext);

            await repository.AddAsync(new PersonAuth() { PersonId = 1 });
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(1, dbContext.PeopleAuths.Count());
        }

        [Test]
        public void PersonAuthRepository_AddAsync_ShouldReturnsArgumentNullException()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextWhitDataTest();
            var repository = new PersonAuthRepository(dbContext);
            PersonAuth entity = null;

            async Task actualy() => await repository.AddAsync(entity);

            Assert.ThrowsAsync<ArgumentNullException>(actualy);
        }

        [Test]
        public async Task PersonAuthRepository_DeleteByIdAsync_DeletesEntityByIs()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            dbContext.PeopleAuths.AddRange(
                new PersonAuth() { PersonId = 1 },
                new PersonAuth() { PersonId = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new PersonAuthRepository(dbContext);

            await repository.DeleteByIdAsync(1);
            await dbContext.SaveChangesAsync();

            Assert.That(dbContext.PeopleAuths.Count(), Is.EqualTo(1), "Failed to delete entity");
            Assert.That(dbContext.PeopleAuths.First().PersonId, Is.EqualTo(2), "Deleted method works incorrect");
        }

        [Test]
        public async Task PersonAuthRepository_GetByIdAsync_ReturnsEntityById()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextTest();
            dbContext.PeopleAuths.AddRange(
                new PersonAuth() { PersonId = 1 },
                new PersonAuth() { PersonId = 2 });
            await dbContext.SaveChangesAsync();

            var repository = new PersonAuthRepository(dbContext);

            var actualy = await repository.GetByIdAsync(2);

            Assert.AreEqual(2, actualy.PersonId);
        }

        [Test]
        public async Task PersonAuthRepository_Update_UpdatesEntity()
        {
            var dbContext = UnitTestHelper.CreateAuthDbContextWhitDataTest();

            var repository = new PersonAuthRepository(dbContext);

            var entity = new PersonAuth() { PersonId = 43, Email = "new Email", Password = "new Password" };

            repository.Update(entity);
            await dbContext.SaveChangesAsync();

            Assert.AreEqual(43, dbContext.PeopleAuths.Find(2).PersonId);
            Assert.AreEqual("new Email", dbContext.PeopleAuths.Find(2).Email);
            Assert.AreEqual("new Password", dbContext.PeopleAuths.Find(2).Password);
        }

    }
}
