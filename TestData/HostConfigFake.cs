using Business.Interfaces;

namespace InternetAuction.Tests
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
