using System.Security.Claims;
using System.Security.Principal;

namespace TestBlog.Core.Extensions
{
    // در این کلاس ما شناسه کلیدی کاربر را به دست میاریم
    public static class IdentityExtentions
    {
        public static long GetUserId(this ClaimsPrincipal claims)
        {
            if (claims != null)
            {
                var data = claims.Claims.SingleOrDefault(o => o.Type == ClaimTypes.NameIdentifier);
                if (data != null) return Convert.ToInt64(data.Value);
            }

            return default(long);
        }

        public static long GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetUserId();
        }

    }
}
