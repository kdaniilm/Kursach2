using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<SignInResult> LoginAsync(LoginViewModel login);
        public Task<User> RegisterAsync(RegisterViewModel register);
    }
}
