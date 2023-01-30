using Microsoft.AspNetCore.DataProtection;

namespace DC.WebApi.Api
{
    public class Constants
    {
        public const string LoginApiPath = "gatekeepr";
        public const string SecuredApiPath = "castle";
        public const string ApiSettingsKey = nameof(ApiSettings);
        public const string JwtRoleName = "role";

        public const string StagingEnviroment = "Staging";
        public const string DevelopmentEnviroment = "Development";
        public const string ProductionEnviroment = "Production";

        public const int MaxImageSize = 400000;
        public static List<string> ValidImageExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
        public const string SecuredFolderName = "Secured";
        public const string ImagesFolderName = "Images";

        public static string ApiImagePath = Path.Combine("api", SecuredApiPath, SecuredFolderName, ImagesFolderName);

        public static string TimeValidationregex = @"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";

        public static string GetMimeType(string imageGuid)
        {
            var extension = Path.GetExtension(imageGuid);
            string mimeType = "";

            if (extension == ".jpg" || extension == ".jpeg")
            {
                mimeType = "image/jpeg";
            }
            else if (extension == ".png")
            {
                mimeType = "image/png";
            }

            return mimeType;
        }

        public static string GetImageGuid(string path)
        {
            string fileName = Path.GetFileName(path);

            if (fileName == default)
                return default;

            return fileName;
        }
    }
}
