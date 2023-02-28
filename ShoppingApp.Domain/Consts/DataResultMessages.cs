using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Consts
{
    public static class DataResultMessages
    {
        #region error
        public const string NoContentResult = "No content";
        public const string MapErrorResult = "Map error";
        public const string UnAuthorizedResult = "Unauthorized error";
        public const string PrivacyError = "Profile privacy error";

        #endregion

        #region success
        public const string SuccessResult = "Success";
        #endregion
    }
}
