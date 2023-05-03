// using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
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

  endpoints.Map("employee/profile/{employeename=khaya}", async context =>
  {
    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"in employee profile - {employeeName}");
  });

  endpoints.Map("products/details/{id=1}", async context =>
  {
    int id = Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"product/details/{id}");
  });
});

app.Run(async context =>
{
  await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
});
app.Run();
