namespace Business.Interfaces
{
    /// <summary>
    /// Provides additional application configuration data.
    /// </summary>
    public interface IHostConfig
    {
        /// <summary>
        /// Path to folder to store images
        /// </summary>
        public string ImagesDirectory { get; }

        /// <summary>
        /// Represents the base part of the URL for downloading files. 
        /// Adding the file name to it, we get the URL for downloading this file.
        /// </summary>
        /// <returns></returns>
        public string GetBaseUrlForUploadImages();
    }
}
