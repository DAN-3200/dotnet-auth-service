using System.Security.Cryptography;
namespace User.Services;

public interface IPasswordHelper
{
   string HashPassword(string password);
   bool VerifyPassword(string hashedPassword, string password);
}

public class PasswordHelper : IPasswordHelper
{
   public string HashPassword(string password)
   {
      byte[] salt = RandomNumberGenerator.GetBytes(16);

      var pbkdf2 = new Rfc2898DeriveBytes(
         password,
         salt,
         100_000,
         HashAlgorithmName.SHA3_256
      );

      byte[] hash = pbkdf2.GetBytes(32);

      var result = new byte[salt.Length + hash.Length];
      Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
      Buffer.BlockCopy(hash, 0, result, salt.Length, hash.Length);

      return Convert.ToBase64String(result);
   }

   public bool VerifyPassword(string hashedPassword, string password)
   {
      var data = Convert.FromBase64String(hashedPassword);
      var salt = data[..16];
      var hash = data[16..];

      var pbkdf2 = new Rfc2898DeriveBytes(
         password,
         salt,
         100_000,
         HashAlgorithmName.SHA256
     );

      var computed = pbkdf2.GetBytes(32);
      return CryptographicOperations.FixedTimeEquals(hash, computed);
   }
}