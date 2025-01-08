using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Helpers.Exceptions.UserExceptions
{
    public class UserRegisterException : Exception
    {
        public UserRegisterException() : base("Register zamani xeta bas verdi") { }

        public UserRegisterException(string? message) : base(message) { }
    }
}
