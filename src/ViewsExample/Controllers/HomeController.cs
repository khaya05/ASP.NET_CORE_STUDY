﻿using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    [Route("home")]
    public IActionResult Index()
    {
      return View();
    }
  }
}
