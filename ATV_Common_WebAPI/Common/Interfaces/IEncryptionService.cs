
namespace ATV_Common_WebAPI.Common.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string plainText, byte[] key, byte[] iv);
        string Decrypt(string cipherText, byte[] key, byte[] iv);
    }
}
