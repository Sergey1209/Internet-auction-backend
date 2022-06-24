using Business.Interfaces;
using System;

namespace InternetAuction.Tests
{
    public partial class UnitTestHelper
    {
        public class HostConfigFake : IHostConfig
        {
            public string ImagesDirectory => "D:\\Images";

            public string GetBaseUrlForUploadImages()
            {
                return @"http:\\test";
            }
        }
    }
}
