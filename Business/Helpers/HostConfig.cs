using Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Business.Helpers
{
    public class HostConfig : IHostConfig
    {
        public string ImagesDirectory { get; }
        private readonly string _hostUrl;
        private readonly string _port;

        public HostConfig(IConfiguration Configuration)
        {
            ImagesDirectory = Configuration.GetSection("ImagesPath").Value;
            _hostUrl = Configuration.GetSection("HostUrl").Value;
            _port = Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORT");
        }

        public string GetBaseUrlForUploadImages()
        {
            return $"{_hostUrl}:{_port}\\api\\files";
        }

    }
}
