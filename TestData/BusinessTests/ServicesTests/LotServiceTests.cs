using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetAuction.Tests.BusinessTests.ServicesTests
{
    public class LotServiceTests
    {
        [Test]
        public async Task LotService_GetAllAsync_ReturnsAllLots()
        {
            //arrange
            var expected = GetTestLotModels();

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.LotRepository.GetAllByDetalsAsync())
                .ReturnsAsync(GetTestLotEntities());

            var LotService = new LotService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile(), new HostConfigFake());

            //act
            var actual = await LotService.GetAllAsync();

            //assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task LotService_AddAsync_ReturnsAllLots()
        {
            //arrange
            var expected = GetTestLotModels();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.LotRepository.AddAsync(It.IsAny<Lot>()));

            var LotService = new LotService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile(), new HostConfigFake());
            var lotModel = GetTestInputLotModels().First();
            //act
            await LotService.AddAsync(lotModel);

            //assert
            mockUnitOfWork.Verify(x => x.LotRepository.AddAsync(It.Is<Lot>(x =>
                                x.Id == lotModel.Id &&
                                x.OwnerId == lotModel.OwnerId &&
                                x.CategoryId == lotModel.CategoryId &&
                                x.Name == lotModel.Name)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        #region TestData

        private IEnumerable<LotModel> GetTestLotModels()
        {
            return new LotModel[] {
                new LotModel() { Id = 1, Name = "Lot1", OwnerId = 1, CategoryId = 1, 
                    Images = new string[]{ "http://test/file1" }, Description = "Description1" },
                new LotModel() { Id = 2, Name = "Lot2", OwnerId = 1, CategoryId = 1, 
                    Images = new string[]{ "http://test/file2" }, Description = "Description1" },
                new LotModel() { Id = 3, Name = "Lot3", OwnerId = 2, CategoryId = 2, 
                    Images = new string[]{ "http://test/file3" }, Description = "Description3" }
                }.AsEnumerable();
        }

        private IEnumerable<InputLotModel> GetTestInputLotModels()
        {
            return new InputLotModel[] {
                new InputLotModel() { Id = 1, Name = "Lot1", OwnerId = 1, CategoryId = 1, Description = "Description1" },
                new InputLotModel() { Id = 2, Name = "Lot2", OwnerId = 1, CategoryId = 1, Description = "Description1"},
                new InputLotModel() { Id = 3, Name = "Lot3", OwnerId = 2, CategoryId = 2, Description = "Description3"}
                }.AsEnumerable();
        }

        private IEnumerable<Lot> GetTestLotEntities()
        {
            return new Lot[] {
                new Lot() { Id = 1, Name = "Lot1", Description = "Description1",
                    CategoryId = 1, Category = new LotCategory(){Id = 1, Name = "LotCategory1" },
                    OwnerId = 1,
                    LotImages = new LotImage[]{
                        new LotImage(){
                            Id = 1,
                            FileId = 1,
                            LotId = 1,
                            File = new File() { Id = 1, Name = "file1"}
                        }
                    }
                },
                new Lot() { Id = 2, Name = "Lot2", Description = "Description1",
                    CategoryId = 1, Category = new LotCategory(){Id = 1, Name = "LotCategory1" },
                    OwnerId = 1,
                    LotImages = new LotImage[]{
                        new LotImage(){
                            Id = 1,
                            FileId = 2,
                            LotId = 2,
                            File = new File() { Id = 2, Name = "file2"}
                        }
                    }
                },
                new Lot() { Id = 3, Name = "Lot3", Description = "Description3",
                    CategoryId = 2, Category = new LotCategory(){Id = 1, Name = "LotCategory1" },
                    OwnerId = 2,
                    LotImages = new LotImage[]{
                        new LotImage(){
                            Id = 1,
                            FileId = 3,
                            LotId = 3,
                            File = new File() { Id = 3, Name = "file3"}
                        }
                    }
                },
                }.AsEnumerable();
        }

        #endregion
    }
}
