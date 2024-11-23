using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Constants
{
    public static class Messages
    {
        public static string UserAlreadyExists = "User already exists";
        public static string EmailOrPasswordIsWrong = "Email or password is wrong";
        public static string SessionHasExpired = "Your session has expired. Please log in again";
        public static string EmailNotValid = "Email not valid";
        public static string CurrentPasswordNotValid = "Current password is not valid";
        public static string AnErrorOccurredWhenPasswordChanging = "An error occurred when password changing";
    }
}
