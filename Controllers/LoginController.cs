using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MovieStore.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        MovieStoreContext db = new MovieStoreContext();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(Users u)
        {
            if (db.Users.Contains(u))
            {
                ViewBag.Error = "User already Exist";
                return View();
            }
            else
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

        }


        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult Login(string search="")
        //{
        //    List<Users> user = db.Users.Where(temp => temp.UserName.Contains(search)).ToList();

        //    ViewBag.Name = db.Users.Where(temp => temp.UserName.Contains(search));
        //    return View();
        //}
        //public IActionResult Result(string search)
        //{
        //    if(db.Users.Contains(search))
        //        {

        //    }
        //    return View();
        //}
        [HttpPost]
        public IActionResult Login(string search)
        {
            string un = Convert.ToString(db.Users.Find(search));
            //string pass = Convert.ToString(db.Users.Find(Password));
            TempData["Users"] = un;
            //if (ModelState.IsValid)
            //{
            //    TempData["Users"] = un;
            //    return RedirectToAction("Result");
            //}
            //else
            //{
            //    ViewBag.Error = "Incorrect User Name or Password, please register or try again";
            //    return View();
            //}

            //List<Users> users = db.Users.ToList();
            //for (int i = 0; i < users.Count; i++)
            //{
            //    Users u = users[i];
            //    if (u.UserName == Name && u.Password == Password)
            //    {
            //        TempData["Users"] = u.UserName;
            //        return RedirectToAction("Index", "Shop");

            //    }
            //}
            //ViewBag.Error = "Incorrect User Name or Password, please register or try again";
            return View();


        }



    }
}
