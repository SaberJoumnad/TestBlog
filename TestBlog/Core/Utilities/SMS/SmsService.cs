
namespace TestBlog.Core.Utilities.SMS
{
    public class SmsService : ISmsService
    {
        public string apiKey = "644458427865494C684C395A64583937776561324454714F50574746766B324E337757384C426E6F3359673D";
        public async Task SendVerificationCode(string mobile, string activeCode)
        {
            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
            await api.VerifyLookup(mobile, activeCode, "TestWebsiteShop");
        }
    }
}
