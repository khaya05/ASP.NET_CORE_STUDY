using IActinResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActinResultExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("bookstore/{bookid?}/{isloggedin?}")]
    public IActionResult Index([FromRoute] int? bookid, bool? isLoggedIn, Book book)
    {
      if(bookid.HasValue == false)
      {
        return BadRequest("book id is not supplied or empty");
      }

      if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
      {
        return BadRequest("book id can't be emplty");
      }

      if(bookid <= 0)
      {
        return NotFound("Book id too small");
      }
      if(bookid > 1000)
      {
        return NotFound("id too large");
      }

      if (isLoggedIn == false)
      {
        return Unauthorized("User must be authenticated");
      }

      return Content($"Book id: {bookid}, Book: {book}", "text/plain");

      // 302
      //return new RedirectToActionResult("Books", "Store", new {});
      //return RedirectToAction("Books", "Store", new { });

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
