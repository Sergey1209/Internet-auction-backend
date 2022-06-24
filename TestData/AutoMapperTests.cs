using Business;
using Business.Helpers;
using Business.Models;
using Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetAuction.Tests
{
    public class AutoMapperTests
    {
        FileHelper _fileHelper;

        [SetUp]
        public void Setup()
        {
            _fileHelper = new FileHelper(@"C:\");
        }

        [Test]
        public void MapLotModelTest()
        {
            var mapper = UnitTestHelper.CreateMapperProfile();
            var lot = new Lot()
            {
                Id = 1,
                Name = "name1",
                Description = "descr1",
                CategoryId = 1,
                OwnerId = 1,
                Receipt = null,
                LotImages = new LotImage[] {
                    new LotImage()
                    {
                        Id = 1,
                        FileId = 1,
                        LotId = 1,
                        File = new File() { Id = 1, Name = "name1.png" }
                    },
                    new LotImage()
                    {
                        Id = 2,
                        FileId = 2,
                        LotId = 1,
                        File = new File() { Id = 2, Name = "name2.png" }
                    }
                }
            };

            var actual = mapper.Map<LotModel>(lot)?.Images?.First();

            var expected = @"http://test/name1.png";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFullName_ReturnSuchNameTest()
        {
            var name = "name1.txt";

            var expected = name;

            var actual = _fileHelper.GetFullNameForSaveFile(name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFullName_ReturnNewNameTest()
        {
            var existFile = new System.IO.DirectoryInfo(@"C:\").GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly).FirstOrDefault(x => x.Extension != "");

            if (existFile == null)
                throw new Exception("Error test");

            var existName = existFile.Name;
            var ext = existFile.Extension;
            var nameWithoutExt = existName.Replace(ext, "");

            var expected = $"{nameWithoutExt}1{ext}";

            var actual = _fileHelper.GetFullNameForSaveFile(existName);

            Assert.AreEqual(expected, actual);
        }
    }
}
