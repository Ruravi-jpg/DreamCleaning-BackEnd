using DC.WebApi.Api;
using DC.WebApi.Common;

namespace DC.WebApi.Core
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _hostEnv;

        public ImageHelper(IWebHostEnvironment hostingEnvironment)
        {
            _hostEnv = hostingEnvironment;
        }
        public void DeleteImage(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<string> SaveImage(IFormFile image, string subFolder)
        {
            string url;

            if (image.Length < 0)
                DCException.ThrowCannotSaveImageInvalidLength();

            if (image.Length > Constants.MaxImageSize)
                DCException.ThrowCannotSaveImageTooLarge();

            string extension = Path.GetExtension(image.FileName);

            if (!Constants.ValidImageExtensions.Contains(extension))
                DCException.ThrowCannotSaveImageInvalidExtension();


            //ContentRoothPath is the path to the root directory of the application 
            string workingDirectory = _hostEnv.ContentRootPath;

            string path;
            //if we have a subfolder, we add it to the path
           if(subFolder == "none")
            {
                path = Path.Combine(workingDirectory, Constants.SecuredFolderName, Constants.ImagesFolderName);
            }
            else
            {
                path = Path.Combine(workingDirectory, Constants.SecuredFolderName, Constants.ImagesFolderName, subFolder);
            }

            //if te directory doesn't exists we have to create it
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid id = Guid.NewGuid();

            url = Path.Combine(path, id + extension);

            using (Stream fileStream = new FileStream(url, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return url;
        }
    }
}
