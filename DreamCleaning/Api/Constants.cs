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
    }
}
