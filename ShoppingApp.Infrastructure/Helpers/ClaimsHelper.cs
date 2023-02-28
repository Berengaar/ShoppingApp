using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Helpers
{
    public class ClaimsHelper
    {
        public static string GetClaimValue(string claimKey, ClaimsPrincipal user)
        {
            try
            {
                if (user.Identity.IsAuthenticated)
                {

                    return user.FindFirst(a => a.Type.EndsWith(claimKey)).Value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static int? GetClaimValueInt(string claimKey, ClaimsPrincipal user)
        {
            try
            {
                if (user.Identity.IsAuthenticated)
                {

                    return Convert.ToInt32(user.FindFirst(a => a.Type.EndsWith(claimKey)).Value);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
