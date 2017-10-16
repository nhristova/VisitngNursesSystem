using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using VNS.Data.Models;
using VNS.Data;
using VNS.Auth.Contracts;
using System.Collections.Generic;

namespace VNS.Auth
{


    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class UserManager : UserManager<User>, IUserService
    {
        public UserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context) 
        {
            var manager = new UserManager(new UserStore<User>(context.Get<MsSqlDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                // TODO: changed to true, check where it's set, update models, add client-side validation
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                // TODO: return to true
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public User GetByUserName(string userName)
        {
            var user = this.FindByName(userName);

            return user;
        }

        public IdentityResult CreateUser(User user, string password)
        {
            var result = this.Create(user, password);

            if (result.Succeeded)
            {
                return this.AddToRole(user.Id, "User");
            }

            return result;
        }

        public IdentityResult MakeAdmin(string userId)
        {
            var result = this.FindById(userId);
            if (result != null)
            {
                return this.AddToRole(userId, "Admin");
            }
            
            return IdentityResult.Failed(); 
        }

        public IList<string> GetUserRoles(string userId)
        {
            IList<string> result = null;
            if (userId != null)
            {
                 result = this.GetRoles(userId);
            }

            return result;
        }

        public IdentityResult AddRole(string userId, string role)
        {
            if (userId != null)
            {
                return this.AddToRole(userId, role);
            }

            return IdentityResult.Failed();
        }
    }    
}
