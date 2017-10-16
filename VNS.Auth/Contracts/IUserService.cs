using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VNS.Data.Models;

namespace VNS.Auth.Contracts
{
    public interface IUserService : IDisposable
    {
        User GetByUserName(string userName);

        IdentityResult CreateUser(User user, string password);

        IdentityResult AddRole(string userId, string role);

        IList<string> GetUserRoles(string userId);

        //
        Task<IdentityResult> CreateAsync(User user);

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<User> FindByNameAsync(string userName);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);

        Task<string> GenerateEmailConfirmationTokenAsync(string userId);

        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);

        Task<bool> IsEmailConfirmedAsync(string userId);

        Task SendEmailAsync(string userId, string subject, string body);

        Task<string> GeneratePasswordResetTokenAsync(string userId);

        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);

        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);
    }
}
