using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Consts
{
    public static class Messages
    {
        #region Errors
        public const string ErrorAdd = "An error occurred while adding.";
        public const string ErrorUpdate = "An error occurred while updating.";
        public const string ErrorDelete = "An error occurred while deleting.";
        public const string ErrorNoContent = "Content was not found";
        public const string ErrorUnauthorized = "Unauthorized";
        public const string ErrorIsExist = "Object already exist";
        public const string ErrorUnit = "Unit is not correct";
        #endregion
    }
}
