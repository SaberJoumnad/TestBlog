using TestBlog.Models.Entities;

namespace TestBlog.Core.Extensions
{
    public static class UserExtensions
    {
        public static string GetUserName(this User user)
        {
            // یعنی اگر کاربر اسمی داشت :
            //if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
            //{
            //    return $"{user.FirstName} {user.LastName}";
            //}


            return $"{user.FirstName} {user.LastName}";

        }
    }
}
