﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketsCorinthiansCore.Controllers
{
    public class HighlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}