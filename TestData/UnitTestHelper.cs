using AutoMapper;
using Business;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace InternetAuction.Tests
{
    public class UnitTestHelper
    {
        public static InternetAuctionDbContext CreateInternetAuctionDbContextTest()
        {
            var options = new DbContextOptionsBuilder<InternetAuctionDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new InternetAuctionDbContext(options);

            return context;
        }

        public static InternetAuctionDbContext CreateInternetAuctionDbContextWhitDataTest()
        {
            var options = new DbContextOptionsBuilder<InternetAuctionDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new InternetAuctionDbContext(options))
            {
                SeedData_InternetAuction(context);
            }

            return new InternetAuctionDbContext(options);
        }

        public static AuthDbContext CreateAuthDbContextTest()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AuthDbContext(options);

            return context;
        }

        public static AuthDbContext CreateAuthDbContextWhitDataTest()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new AuthDbContext(options))
            {
                SeedData_Auth(context);
            }

            return new AuthDbContext(options);
        }

        public static IMapper CreateMapperProfile()
        {
            var hostConfig = new HostConfigFake();
            var profile = new AutomapperProfile(hostConfig);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return new Mapper(configuration);
        }


        public static void SeedData_InternetAuction(InternetAuctionDbContext context)
        {
            context.LotCategories.AddRange(
                new LotCategory() { Id = 1, Name = "cat1", FileId = 1 },
                new LotCategory() { Id = 2, Name = "cat2", FileId = 2 });

            context.Lots.AddRange(
                new Lot()
                {
                    Id = 1,
                    Name = "lot1",
                    Description = "Description1",
                    CategoryId = 2,
                    InitialPrice = 12.65m,
                    OwnerId = 1
                },
                new Lot() { Id = 3, Name = "lot3", Description = "Description3", CategoryId = 2, InitialPrice = 12.65m, OwnerId = 1 },
                new Lot() { Id = 2, Name = "lot2", Description = "Description2", CategoryId = 1, InitialPrice = 2_000_000m, OwnerId = 1 }
            );

            context.LotImages.AddRange(
                new LotImage() { Id = 1, LotId = 1, FileId = 11 },
                new LotImage() { Id = 3, LotId = 2, FileId = 12 },
                new LotImage() { Id = 2, LotId = 3, FileId = 13 }
            );

            context.Receipts.AddRange(
                new Receipt() { Id = 1, Cost = 200m, CustomerId = 1, LotId = 1, OperationDate = new DateTime(year: 2020, month: 9, day: 12) },
                new Receipt() { Id = 2, Cost = 2_567_898m, CustomerId = 1, LotId = 2, OperationDate = new DateTime(year: 2021, month: 2, day: 13) }
            );

            context.Files.AddRange(
                new File() { Id = 1, Name = "filename1" },
                new File() { Id = 2, Name = "filename2" },
                new File() { Id = 3, Name = "filename3" },
                new File() { Id = 11, Name = "filename11" },
                new File() { Id = 12, Name = "filename12" },
                new File() { Id = 13, Name = "filename13" }
                );

            context.SaveChanges();
        }

        public static void SeedData_Auth(AuthDbContext context)
        {
            context.People.AddRange(
                new Person() { Id = 1, Nickname = "person1" },
                new Person() { Id = 2, Nickname = "person2" });

            context.PeopleAuths.AddRange(
                new PersonAuth() { Email = "e1@gmail.com", Password = "pass1", PersonId = 2 },
                new PersonAuth() { Email = "e2@gmail.com", Password = "pass2", PersonId = 1 });

            context.SaveChanges();
        }
    }
}
