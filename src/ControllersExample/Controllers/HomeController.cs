using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
  public class HomeController
  {
    [Route("/")]
    public string method1()
    {
      return "hello from method1";
    }
  }
}
