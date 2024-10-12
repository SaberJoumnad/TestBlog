namespace TestBlog.Core.Utilities.Password
{
    public interface IPasswordHelper
    {
        string EncodePasswordMd5(string password);
    }
}
