using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Todo.Common.Dto;
using Todo.Core.Repositories.RepositoryInterfaces;

namespace Todo.Presentation.Controllers
{
    [AllowAnonymous]
    public class IdentityController : Controller
    {
        [Route("giris")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route("giris")]
        [HttpPost]
        public ActionResult Login(DtoLogin model)
        {
            var user =  (DtoUser)ApiRequester.Call<DtoUser>("identityapi/validatelogin", "POST", postData: model).Data;

            if (user != null)
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.EMailAddress),
                new Claim(ClaimTypes.Country, "")}, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect((model.ReturnUrl));
            }

            return View(model);
        }

        [Route("cikis")]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "home");
        }
    }
}