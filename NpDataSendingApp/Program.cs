HttpClient client = new();

//Dictionary<string, string> data = new Dictionary<string, string>()
//{
//    ["name"] = "Bobby",
//    ["age"] = "27",
//    ["position"] = "manager"
//};

//HttpContent content = new FormUrlEncodedContent(data);

//var response = await client.PostAsync("https://localhost:7159/data", content);

//var text = await response.Content.ReadAsStringAsync();

//Console.WriteLine(text);

string imageName = @"E:\image01.jpg";
using (var stream = File.OpenRead(imageName))
{
    StreamContent content = new StreamContent(stream);
    using (var response = await client.PostAsync("https://localhost:7159/image", content))
    {
        string text = await response.Content.ReadAsStringAsync();
        Console.WriteLine(text);
    }
}