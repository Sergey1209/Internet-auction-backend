using Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Business.Helpers
{
    /// <summary>
    /// Provides additional application configuration data.
    /// </summary>
    public class HostConfig : IHostConfig
    {
        /// <summary>
        /// Path to folder to store images
        /// </summary>
        public string ImagesDirectory { get; }
        private readonly string _hostUrl;
        private readonly string _port;

        public HostConfig(IConfiguration Configuration)
        {
            ImagesDirectory = Configuration.GetSection("ImagesPath").Value;
            _hostUrl = Configuration.GetSection("HostUrl").Value;
            _port = Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORT");
        }

        /// <summary>
        /// Represents the base part of the URL for downloading files. 
        /// Adding the file name to it, we get the URL for downloading this file.
        /// </summary>
        /// <returns></returns>
        public string GetBaseUrlForUploadImages()
        {
            return $"{_hostUrl}:{_port}\\api\\files";
        }

    }
}
