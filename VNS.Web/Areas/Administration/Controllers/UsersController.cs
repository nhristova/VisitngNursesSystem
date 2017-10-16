using Bytes2you.Validation;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VNS.Auth.Contracts;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Areas.Administration.Models;

namespace VNS.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IPageService<User> pageService;
        private readonly IUserService usersService;

        public UsersController(IUserService userManager, IPageService<User> pageService)
        {
            Guard.WhenArgument(userManager, "usersService").IsNull().Throw();
            Guard.WhenArgument(pageService, "pageService").IsNull().Throw();
            this.usersService = userManager;
            this.pageService = pageService;
        }

        public ActionResult Details(string username)
        {
            if(username == "default" || username == null)
            {
                // TODO no such user redirect or??
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find in database
            var user = this.usersService.GetByUserName(username);

            if (user == null)
            {
                return HttpNotFound();
            }

            // Convert data to view model
            var vm = new UserDetailsViewModel(user);
            vm.UserRoles = this.usersService.GetUserRoles(vm.Id);
            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(UserDetailsViewModel userViewModel)
        {
            
            if (ModelState.IsValid)
            {
                // TODO: Call user create method??
                var user = new User()
                {
                    UserName = userViewModel.UserName,
                    Email = userViewModel.Email,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    PhoneNumber = userViewModel.PhoneNumber,
                    CreatedOn = DateTime.Now
                    
                };
                this.usersService.CreateUser(user, userViewModel.PasswordHash);

                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }

        public ActionResult Edit(string username)
        {
            // TODO check should be for the default value from the route mapping
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find in database
            var user = this.usersService.GetByUserName(username);
            // TODO do something if user not found
            if (user == null)
            {
                return HttpNotFound();
            }
            // Convert data to view model
            var vm = new UserDetailsViewModel(user);
            return View(vm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(UserDetailsViewModel user)
        {
            if (ModelState.IsValid)
            {
                // TODO: find and edit
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Deactivate(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            // TODO: find 
            var user = (User)null;
            if (user == null)
            {
                return HttpNotFound();
            }
            // TODO: deactivate
            user.IsDeleted = true;

            // TODO: maybe do something else
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            // TODO: find
            var user = (User)null;
            user.IsDeleted = true;
            // TODO: save changes
            return RedirectToAction("Index");
        }

        public ActionResult List(short page = 1, short pageSize = 6, string orderBy = "CreatedOn")
        {
            var pagedUsers = this.pageService
                .GetPage(page, pageSize, orderBy)
                .Select(v => new UserRowViewModel(v))
                .ToList();

            // TODO how to do this better, doesn't work for many users only for one, why??
            foreach (var user in pagedUsers)
            {
                user.UserRoles = this.usersService.GetUserRoles(user.Id);
            }
            
            var pages = this.pageService.Count / pageSize;
            pages = this.pageService.Count % pageSize == 0 ? pages : ++pages;

            var vm = new UsersViewModel()
            {
                Users = pagedUsers,
                PageCount = pages
            };

            return this.PartialView("_UsersListPartial", vm);
        }


        //[HttpPost]
        public ActionResult MakeAdmin(string userId)
        {
            //if(this.Request.IsAjaxRequest)
            // TODO return something better
            if (userId != null)
            {
                this.usersService.AddRole(userId, "Admin");
                return Content("OK");
            }
            return Content("Id is null");
        }
    }
}