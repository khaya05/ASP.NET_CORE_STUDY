using Microsoft.AspNetCore.Mvc;

namespace IActinResultExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("bookstore")]
    public IActionResult Index()
    {
      if(!Request.Query.ContainsKey("bookId"))
      {
        return BadRequest("book id is not supplied");
      }

      if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
      {
        return BadRequest("book id can't be emplty");
      }

      //book id should be 1 to 1000
      int id = Convert.ToInt32(Request.Query["bookId"]);

      if(id <= 0)
      {
        return NotFound("Book id too small");
      }
      if(id > 1000)
      {
        return NotFound("id too large");
      }

      if (Convert.ToBoolean(Request.Query["isloggedin"] == false))
      {
        return Unauthorized("User must be authenticated");
      }

      // 302
      //return new RedirectToActionResult("Books", "Store", new {});
      // return RedirectToAction("Books", "Store", new { });

      // 301 - moved permanently
      // return new RedirectToActionResult("Books", "Store", new { },true);
      // return new RedirectToActionPermanent("Books", "Store", new { });

      // cannot redirect to other websites
      //local redirect- 302
      // return new LocalRedirectResult($"store/books");
      // return LocalRedirect($"store/books");

      //local redirect- 301
      // return new LocalRedirectResult($"store/books", true);
      // return LocalRedirectPermanent($"store/books");

      //redirect result - can redirect to other websites
      //302
      // return RedirectResult(url)
      //301
      // return RedirectResultPermanent(url)

    }
  }
}
