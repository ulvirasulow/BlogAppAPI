using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Helpers.Exceptions.UserExceptions
{
    public class UserLoginFailedException : Exception
    {
        public UserLoginFailedException() : base("Username ve ya password yanlisdir") { }
        
        public UserLoginFailedException(string? message) : base(message) { }
    }
}
