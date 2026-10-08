using Microsoft.AspNetCore.Rewrite;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// add custom middleware to log request details to console
app.Use(async (context, next) =>
{
    await next();
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});

app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));
// This code adds a URL rewriter middleware component that redirects requests from /history to /about

app.MapGet("/", () => "Welcome to Contoso!");

app.MapGet("/about", () => "Contoso was founded in 2000.");
// This code adds another endpoint. If the request path is /about, the endpoint writes "Our company was founded in 2000." to the response.


app.Run();
