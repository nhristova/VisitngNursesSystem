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
    public class UsersController : Controller
    {
        private readonly IPageService<User> pageService;
        private readonly IUserService usersService;

        public UsersController(IUserService usersService, IPageService<User> pageService)
        {
            Guard.WhenArgument(usersService, "usersService").IsNull().Throw();
            Guard.WhenArgument(pageService, "pageService").IsNull().Throw();
            this.usersService = usersService;
            this.pageService = pageService;
        }

        public ActionResult Details(Guid? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO find
            var visit = "";
            if (visit == null)
            {
                return HttpNotFound();
            }
            // TODO convert to view
            return View(visit);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(UserRowViewModel user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Call user create method
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // TODO: Find
            var user = (User)null;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(UserRowViewModel user)
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

        public ActionResult List(short page = 1, short pageSize = 5, string orderBy = "CreatedOn")
        {
            var pagedUsers = this.pageService
                .GetPage(page, pageSize, orderBy)
                .Select(v => new UserRowViewModel(v));

            var pages = this.pageService.Count / pageSize;
            pages = this.pageService.Count % pageSize == 0 ? pages : ++pages;

            var vm = new UsersViewModel()
            {
                Users = pagedUsers,
                PageCount = pages
            };

            return this.PartialView("_UsersListPartial", vm);
        }
    }
}