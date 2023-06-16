
using ASP;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = context.Request.Path;
    string jsonFilePath = "JSON/user.json";

    if (path == "/task1")
    {
        await context.Response.WriteAsync("Hello!");
    }
    else if (path == "/task2")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}\n");
        await context.Response.WriteAsync($"Time: {DateTime.Now.ToShortTimeString()}");
    }
    else if (path == "/task3")
    {
        try
        {
            User user = new User("John Doe", 30, "Software Developer");

            string jsonString = JsonConvert.SerializeObject(user);
            File.WriteAllText(jsonFilePath, jsonString);

            if (File.Exists(jsonFilePath))
            {
                response.ContentType = "json";
                await response.SendFileAsync(jsonFilePath);
            }
            else
            {
                throw new Exception("404 Error!");
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 404;
            await response.WriteAsJsonAsync(new { message = ex.Message });
        }
    }
    else if (path == "/task4")
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                User user = JsonConvert.DeserializeObject<User>(jsonContent);
                if (user != null)
                {
                    await response.WriteAsync(user.ToString());
                }
                else
                {
                    throw new Exception("Empty file error!");
                }
            }
            else
            {
                throw new Exception("404 Error!");
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 404;
            await response.WriteAsJsonAsync(new { message = ex.Message });
        }
        
    }
    else if (path == "/task5")
    {
        try
        {
            string category = "happiness";
            string apiUrl = "https://api.api-ninjas.com/v1/quotes?category=" + category;
            string apiKey = "P0zLfP0p+57v4OOJJGQUxw==0ZLc4QgaVx7PnElJ";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
                HttpResponseMessage quoteResponse = await client.GetAsync(apiUrl);

                if (quoteResponse.IsSuccessStatusCode)
                {
                    string result = await quoteResponse.Content.ReadAsStringAsync();
                    await response.WriteAsync(result);
                }
                else
                {
                    throw new Exception("Error!");
                }
            }
        }
        catch (Exception ex)
        {
            await response.WriteAsJsonAsync(new { message = ex.Message });
        }
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("pages/index.html");
    }
});

app.Run();