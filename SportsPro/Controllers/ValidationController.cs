using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Controllers
{
    public class ValidationController : Controller
    {
        private SportsProContext context;
        public ValidationController(SportsProContext ctx) => context = ctx;

        public JsonResult CheckEmail(string Email)
        {
            string msg = Check.EmailExists(context, Email);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
