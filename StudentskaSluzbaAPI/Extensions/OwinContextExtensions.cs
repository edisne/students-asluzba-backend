using Microsoft.Owin;

namespace StudentskaSluzbaAPI.Extensions
{
    public static class OwinContextExtensions
    {
        public static string GetUserId(this IOwinContext ctx)
        {
            var result = "-1";
            var claim = ctx.Authentication.User.Claims.FirstOrDefault(c=>c.Type == "UserId");
           if (claim != null)
            {
                result = claim.Value;
            }
           return result;
        }
    }
}
