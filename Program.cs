
using System.Text.RegularExpressions;
using ASP;

List<Car> cars = new List<Car>()
{
    new Car(Guid.NewGuid().ToString(), "Audi", "A8", 2010),
    new Car(Guid.NewGuid().ToString(), "Suzuki", "Vitara", 2014),
    new Car(Guid.NewGuid().ToString(), "BMW", "X5", 2012),
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = context.Request.Path;
    string expressionForGuid = @"^/api/cars/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

    if (path == "/api/cars" && request.Method == "GET")
    {
        await GetAllCars(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        string id = path.Value?.Split("/")[3];
        await GetCarById(response, id);
    }
    else if (path == "/api/cars" && request.Method == "POST")
    {
        await CreateCar(response, request);
    }
    else if (path == "/api/cars" && request.Method == "PUT")
    {
        await UpdateCar(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {

    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("pages/index.html");
    }
});

app.Run();

async Task GetAllCars(HttpResponse httpResponse)
{
    await httpResponse.WriteAsJsonAsync(cars);
}

async Task CreateCar(HttpResponse httpResponse, HttpRequest httpRequest)
{
    try
    {
        Car car = await httpRequest.ReadFromJsonAsync<Car>();
        if (car != null)
        {
            car.Id = Guid.NewGuid().ToString();
            cars.Add(car);
            await httpResponse.WriteAsJsonAsync(car);
        }
        else
        {
            throw new Exception("Serialization exception");
        }
    }
    catch (Exception ex)
    {
        httpResponse.StatusCode = 400;
        await httpResponse.WriteAsJsonAsync(new { message = ex.Message });
    }
}

async Task GetCarById(HttpResponse httpResponse, string id)
{
    try
    {
        Car? car = cars.FirstOrDefault(x => x.Id == id);
        if (car != null)
        {
            await httpResponse.WriteAsJsonAsync(car);
        }
        else
        {
            throw new Exception("404 Error!");
        }
    }
    catch (Exception ex)
    {
        httpResponse.StatusCode = 404;
        await httpResponse.WriteAsJsonAsync(new { message = ex.Message });
    }
}

async Task UpdateCar(HttpResponse httpResponse, HttpRequest httpRequest)
{
    Car car = await httpRequest.ReadFromJsonAsync<Car>();
    if (car != null)
    {
        Car oldCar = cars.FirstOrDefault(o => o.Id == car.Id);
        if (oldCar != null)
        {
            oldCar.Brand = car.Brand;
            oldCar.Model = car.Model;
            oldCar.Year = car.Year;
            await httpResponse.WriteAsJsonAsync(oldCar);
        }
    }
}