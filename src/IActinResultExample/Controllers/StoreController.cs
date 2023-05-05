using Microsoft.AspNetCore.Mvc;

namespace IActinResultExample.Controllers
{
  public class StoreController : Controller
  {
    [Route("store/books")]
    public IActionResult Books()
    {
      return View();
    }
  }
}
 