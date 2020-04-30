﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportBook.Models;

namespace SportBook.Controllers
{
    //[Authorize(Roles = "user, admin")]
    [Route("[action]")]
    public class EsportsController : Controller
    {
        public IActionResult Esports()
        {
            return View();
        }
        public IActionResult Tournaments()
        {
            return RedirectToAction("Index", "Events");
        }
        public IActionResult Teams()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}