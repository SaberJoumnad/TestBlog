namespace TestBlog.Core.Utilities.SMS
{
    public interface ISmsService
    {
        Task SendVerificationCode(string mobile, string activeCode);
    }
}
