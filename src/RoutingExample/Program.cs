using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
  options.ConstraintMap.Add("months", typeof(MonthsCustomConstraints));
});

var app = builder.Build();

app.UseRouting();

// creating endpoints
app.UseEndpoints(endpoints =>
{
endpoints.Map("files/{filename}.{extension}", async context =>
{
  string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
  string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

  await context.Response.WriteAsync($"in files- {filename}.{extension}");
});

  endpoints.Map("employee/profile/{employeename:minlength(2)=khaya}", async context =>
  {
    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"in employee profile - {employeeName}");
  });

  endpoints.Map("products/details/{id=1}", async context =>
  {
    int id = Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"product/details/{id}");
  });

  endpoints.Map("daily-report/{reportdate:datetime}", async context =>
  {
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
    await context.Response.WriteAsync($"In daily-report - {reportDate.ToShortDateString()}");
  });

  endpoints.Map("cities/{cityid:guid}", async context =>
  {
    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["Cityid"])!);
    await context.Response.WriteAsync($"City information - {cityId}");
  });

  // sales report/2030/apr
  endpoints.Map("sales-report/{year:int:min(1990)/{month:months}", async context =>
  {
    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
    string? month = Convert.ToString(context.Request.RouteValues["month"]);

    if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
    {
      await context.Response.WriteAsync($"sales report - {year} - {month}");
    }
    else
    {
      await context.Response.WriteAsync($"{month} is not allowed");
    }
  });


});

app.Run(async context =>
{
  await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
});
app.Run();
