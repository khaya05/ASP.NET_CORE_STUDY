using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
  public class HomeController: Controller
  {
    [Route("/")]
    [Route("home")]
    public IActionResult Index()
    {
      //return Content("hello from index", "text/html");
      return Content("<h1>Hello from index</h1>", "text/html");

    }

    [Route("about")]
    public string About()
    {
      return "hello from about";
    }

    [Route("download-1")]
    public IActionResult Download1()
    {
      //return new VirtualFileResult("/doc.html", "text/html");
      return File("/doc.html", "text/html");
    }

    [Route("download-2")]
    public IActionResult Download2()
    {
      //return new PhysicalFileResult(@"C:\Users\Student\Desktop\.NET\ASP.NET_CORE_STUDY\src\StaticFilesexample\wwwroot\eula.1028.txt", "plain/text");
      return PhysicalFile(@"C:\Users\Student\Desktop\.NET\ASP.NET_CORE_STUDY\src\StaticFilesexample\wwwroot\eula.1028.txt", "plain/text");
    }

    [Route("person")]
    public IActionResult Person()
    {
      Person person = new Person() {
        Id=Guid.NewGuid(), FirstName="James", LastName="May", Age=63 
      };

      //return new JsonResult(person);
      return Json(person);
    }
  }
}
