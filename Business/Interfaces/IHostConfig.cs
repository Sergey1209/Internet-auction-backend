namespace Business.Interfaces
{
    public interface IHostConfig
    {
        public string ImagesDirectory { get; }
        public string GetBaseUrlForUploadImages();
    }
}
