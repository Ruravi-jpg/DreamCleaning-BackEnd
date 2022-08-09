namespace DC.WebApi.Core
{
    public interface IPasswordHelper
    {

        byte[] GenerateHash(string password, byte[] salt);
        byte[] GenerateSalt();
    }
}
