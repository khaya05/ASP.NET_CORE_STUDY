using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
  [Controller]
  public class HomeController
  {
    [Route("/")]
    [Route("home")]
    public string Index()
    {
      return "hello from index";
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
