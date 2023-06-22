
using System.Text.RegularExpressions;
using ASP.Classes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = context.Request.Path;
    string expressionForCarsGuid = @"^/api/cars/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    string expressionForBikesGuid = @"^/api/bikes/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

    if (path == "/carstask")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Pages/cars.html");
    }
    else if (path == "/bikestask")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Pages/bikes.html");
    }
    else if (path == "/about")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Pages/about.html");
    }
    else if (path == "/home")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Pages/home.html");
    }


    else if (path == "/api/cars" && request.Method == "GET")
    {
        await CarOperations.GetAllCars(response);
    }
    else if (Regex.IsMatch(path, expressionForCarsGuid) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await CarOperations.GetCarById(response, id);
    }
    else if (path == "/api/cars" && request.Method == "POST")
    {
        await CarOperations.CreateCar(response, request);
    }
    else if (path == "/api/cars" && request.Method == "PUT")
    {
        await CarOperations.UpdateCar(response, request);
    }
    else if (Regex.IsMatch(path, expressionForCarsGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await CarOperations.DeleteCar(id, response);
    }
    
    else if (path == "/api/bikes" && request.Method == "GET")
    {
        await BikeOperations.GetAllBikesPagination(response, 1, 5);
    }
    else if (Regex.IsMatch(path, expressionForBikesGuid) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await BikeOperations.GetBikeById(response, id);
    }
    else if (path == "/api/bikes" && request.Method == "POST")
    {
        await BikeOperations.CreateBike(response, request);
    }
    else if (path == "/api/bikes" && request.Method == "PUT")
    {
        await BikeOperations.UpdateBike(response, request);
    }
    else if (Regex.IsMatch(path, expressionForBikesGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await BikeOperations.DeleteBike(id, response);
    }

    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Pages/index.html");
    }
});

app.Run();