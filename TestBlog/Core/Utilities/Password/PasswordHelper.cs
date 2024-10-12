using System.Security.Cryptography;
using System.Text;

namespace TestBlog.Core.Utilities.Password
{
    public class PasswordHelper : IPasswordHelper
    {
        public string EncodePasswordMd5(string pass) //Encrypt using MD5
        {
            byte[] originalBytes;
            byte[] encodeBytes;
            MD5 md5;
            // Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encode password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodeBytes = md5.ComputeHash(originalBytes);
            // convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodeBytes);
        }
    }
}
