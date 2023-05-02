using System;

namespace MiddleWareExample.CustomMiddleware;
public class MyCustomMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    await context.Response.WriteAsync("My custom middleware - starts");
    await next(context);
    await context.Response.WriteAsync("My custom middleware - ends!");
  }
}

public static class CustomMiddlewareExtension
{
  public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
  {
    return app.UseMiddleware<MyCustomMiddleware>();
  }
}