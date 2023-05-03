using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> countries = new Dictionary<int, string>()
{
  {1, "USA" },
  {2, "Canada" },
  {3, "UK" },
  {4, "India" },
  {5, "Japan" }
};

app.UseRouting();

string GetCountryById(int id)
{
  if (countries.TryGetValue(id, out string? value))
  {
    return $"{id}, {value}";
  }
  return null;
}

app.UseEndpoints(endpoints =>
{
  endpoints.MapGet("/countries", async context =>
  {
    context.Response.StatusCode = 200;
    string responseContent = string.Join("\n", countries.Select(kv => GetCountryById(kv.Key)));
    await context.Response.WriteAsync(responseContent);
  });

  endpoints.MapGet("countries/{id:int:range(1, 100)}", async context =>
  {
    if (!int.TryParse(context.Request.RouteValues["id"]?.ToString(), out int id))
    {
      context.Response.StatusCode = 400;
      await context.Response.WriteAsync("Invalid ID");
      return;
    }

    if (countries.TryGetValue(id, out string? value))
    {
      string country = GetCountryById(id);
      context.Response.StatusCode = 200;
      await context.Response.WriteAsync(country);
    }
    else
    {
      context.Response.StatusCode = 404;
      await context.Response.WriteAsync($"country not found");
    }

  });
});


app.Run(async context =>
{
  await context.Response.WriteAsync("Home page");
});

app.Run();
