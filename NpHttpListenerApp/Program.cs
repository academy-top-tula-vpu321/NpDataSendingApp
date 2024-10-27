using System.Net;
using System.Text;

HttpListener server = new HttpListener();

server.Prefixes.Add("https://localhost:5000/");

server.Start();
Console.WriteLine($"Server started");
foreach(var p in server.Prefixes)
    Console.WriteLine(p);

var context = await server.GetContextAsync();
var response = context.Response;

string html = @"<!DOCTYPE html>
<html>
    <head>
        <meta charset='utf8'>
        <title>Web server</title>
    </head>
    <body>
        <h1>Hello world</h1>
        <h3>Hello people</h3>
    </body>
</html>";

byte[] buffer = Encoding.UTF8.GetBytes(html);
response.ContentLength64 = buffer.Length;

using Stream stream = response.OutputStream;

await stream.WriteAsync(buffer);
await stream.FlushAsync();

server.Stop();