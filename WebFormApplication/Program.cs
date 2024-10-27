var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", (HttpContext context) =>
{
    context.Response.Cookies.Append("login", "memeber");
    context.Response.Cookies.Append("password", "qwerty");
});

app.MapPost("/data", async (HttpContext context) => {
    var form = context.Request.Form;
    string? name = form["name"];
    string? age = form["age"];
    string? position = form["position"];

    await context.Response.WriteAsync($"Name: {name}, Age: {age}. Position: {position}");
});

app.MapPost("/image", async (HttpContext context) =>
{
    var downloadFolder = $"{Directory.GetCurrentDirectory()}/download";
    if (!Directory.Exists(downloadFolder))
        Directory.CreateDirectory(downloadFolder);
    string nameFileGuid = Guid.NewGuid().ToString() + ".jpg";

    using(FileStream stream = new FileStream($"{downloadFolder}/{nameFileGuid}", FileMode.Create))
    {
        await context.Request.Body.CopyToAsync(stream);
    }

    await context.Response.WriteAsync("Image downloded");
});

app.Run();
