
namespace TestBlog.Core.Utilities.SMS
{
    public class SmsService : ISmsService
    {
        // در این پروژه از سرویس پیامکی کاوه نگار استفاده شده
        // در پراپرتی زیر ای پی آی که از سرویس کاوه نگار دریافت کردید را وارد کنید
        public string apiKey = "";
        public async Task SendVerificationCode(string mobile, string activeCode)
        {
            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);

            // در جای رشته خالی نام مدل ارسال اس ام اس که در پنل کاوه نگار تعریف کردید را وارد کنید
            await api.VerifyLookup(mobile, activeCode, "");
        }
    }
}
