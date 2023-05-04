using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
  public class HomeController: Controller
  {
    [Route("/")]
    [Route("home")]
    public ContentResult Index()
    {
      //return Content("hello from index", "text/html");
      return Content("<h1>Hello from index</h1>", "text/html");

    }

    [Route("about")]
    public string About()
    {
      return "hello from about";
    }

    [Route("contact/")]
    public string Contact()
    {
      return "hello from contact";
    }
  }
}
