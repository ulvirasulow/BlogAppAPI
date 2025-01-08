using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.DTOs.User;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
