namespace DC.WebApi.Core
{
    public interface IImageHelper
    {
        Task<string> SaveImage(IFormFile image, string subFolder = "none");

        void DeleteImage(string path);
    }
}
