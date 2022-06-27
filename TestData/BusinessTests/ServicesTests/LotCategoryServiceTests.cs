using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetAuction.Tests.BusinessTests.ServicesTests
{
    [TestFixture]
    public class LotCategoryServiceTests
    {
        [Test]
        public async Task LotCategoryService_GetAllAsync_ReturnsAllCategory()
        {
            //arrange
            var expected = GetTestLotCategoryModels();

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.LotCategoryRepository.GetAllByDetalsAsync())
                .ReturnsAsync(GetTestLotCategoryEntities());

            var lotCategoryService = new LotCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //act
            var actual = await lotCategoryService.GetAllAsync();

            //assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task LotCategoryService_GetByIdAsync_ReturnValue()
        {
            //arrange
            var expected = GetTestLotCategoryModels().First();

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.LotCategoryRepository.GetByIdWithDetailsAsync(It.IsAny<int>()))
                .ReturnsAsync(GetTestLotCategoryEntities().First());

            var lotCategoryService = new LotCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //act
            var actual = await lotCategoryService.GetByIdAsync(1);

            //assert
            actual.Should().BeEquivalentTo(expected);
        }

        #region TestData

        private IEnumerable<LotCategoryModel> GetTestLotCategoryModels()
        {
            return new LotCategoryModel[] {
                new LotCategoryModel() { Id = 1, Name = "Name1", UrlIcon = "http://test/file1.png" },
                new LotCategoryModel() { Id = 2, Name = "Name2", UrlIcon = "http://test/file2.png" },
                new LotCategoryModel() { Id = 3, Name = "Name3", UrlIcon = "http://test/file3.png" }
                }.AsEnumerable();
        }

        private IEnumerable<LotCategory> GetTestLotCategoryEntities()
        {
            return new LotCategory[] {
                new LotCategory() { Id = 1, Name = "Name1", FileId = 1, File = new File(){ Id = 1, Name = "file1.png"} },
                new LotCategory() { Id = 2, Name = "Name2", FileId = 2, File = new File(){ Id = 2, Name = "file2.png"} },
                new LotCategory() { Id = 3, Name = "Name3", FileId = 3, File = new File(){ Id = 3, Name = "file3.png"} }
                }.AsEnumerable();
        }
        #endregion
    }
}
