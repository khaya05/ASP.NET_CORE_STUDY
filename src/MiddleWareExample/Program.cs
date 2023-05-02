using MiddleWareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// middleware 1
app.Use(async(HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Hello");
  await next(context);
});

// middleware 2: custom middleware
app.UseMiddleware<MyCustomMiddleware>();

app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Hey");
});
app.Run();
