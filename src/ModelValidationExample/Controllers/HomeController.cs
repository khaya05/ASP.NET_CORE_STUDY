using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.Modals;

namespace ModelValidationExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("register")]
    public IActionResult Index(Person person)
    {
      return Content($"{person}");
    }
  }
}
