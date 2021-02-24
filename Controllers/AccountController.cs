using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Orphanage.Models;
using Orphanage.Infrastructure;
using System.Security.Cryptography;
using System.Text;
using Orphanage.Infrastructure;
using Microsoft.AspNetCore.Http;
namespace Orphanage.Controllers
{
    public class AccountController : Controller

    {
        private NGODbContext context;
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public AccountController(IHttpContextAccessor content, NGODbContext _context, ILogger<AccountController> logger)
        {
            context = _context;
            _logger = logger;
            _httpContextAccessor = content;
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        [Route("/Account/Login")]
        public ActionResult Login()
        {
            return View();
        }

        //admin
        [HttpGet]
        [Route("/Admin/Login")]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Admin/Login")]
        public ActionResult AdminLogin(Admin AdminModel)
        {
            if (ModelState.IsValid)
            {
                var data = context.Admins.Where(s => s.username.Equals(AdminModel.username) && s.password.Equals(AdminModel.password)).ToList();
                if (data.Count() > 0)
                {

                    ////add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["idUser"] = data.FirstOrDefault().idUser;

                    _session.SetString("Admin", data.FirstOrDefault().username);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Incorect login details");
                    return View();
                }
            }
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = context.Users.FirstOrDefault(s => s.email == _user.email);
                if (check == null)
                {
                    _user.password = GetMD5(_user.password);
                  //  context.Configuration.ValidateOnSaveEnabled = false;
                    context.Users.Add(_user);
                    context.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View();
                }


            }
            return View();


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login LoginModel)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(LoginModel.password);
                var data = context.Users.Where(s => s.email.Equals(LoginModel.email) && s.password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {

                    ////add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["idUser"] = data.FirstOrDefault().idUser;

                    _session.SetString("email", data.FirstOrDefault().email);
                    _session.SetString("name", data.FirstOrDefault().name);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry, Incorrect details!");
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        //Logout
        [Route("/Logout")]
        public ActionResult Logout()
        {
            _session.Clear();//remove session
            return Redirect("/Home/Index");
        }




    }
}
