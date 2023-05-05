using Microsoft.AspNetCore.Mvc;

namespace Assignment_10.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public IActionResult Index()
    {
      return Content("Welcome to the Best Bank");
    }

    [Route("account-details")]
    public IActionResult AccountDetails()
    {
      return Json(new { accountNumber = 1001, accountHolderName = "Don", currentBalance = 5000 });  
    }

    [Route("account-statement")]
    public IActionResult AccountStatement() 
    {
      return File("/js.pdf", "application/pdf");
    }

    [Route("get-current-balance/{accno:int}")]
    public IActionResult AccountBalance()
    {
      if (!Request.Query.ContainsKey("accno"))
      {
        return NotFound();
      }

      if (Convert.ToString(Request.Query["accno"]) != "1001")
      {
        return BadRequest();
      }
      return Content("5000");
    }
  }
}
