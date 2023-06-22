
namespace ASP.Classes
{
    public static class BikeOperations
    {
        static List<Bike> bikes = new List<Bike>()
        {
            new Bike(Guid.NewGuid().ToString(), "Model1", 2021, 9000),
            new Bike(Guid.NewGuid().ToString(), "Model2", 2022, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model3", 2022, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model4", 2022, 14000),
            new Bike(Guid.NewGuid().ToString(), "Model5", 2020, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model6", 2018, 12000),
            new Bike(Guid.NewGuid().ToString(), "Model7", 2022, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model8", 2022, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model9", 2022, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model10", 2022, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model11", 2018, 10000),
            new Bike(Guid.NewGuid().ToString(), "Model12", 2022, 15000),
            new Bike(Guid.NewGuid().ToString(), "Model13", 2022, 16000),
            new Bike(Guid.NewGuid().ToString(), "Model14", 2017, 11000),
            new Bike(Guid.NewGuid().ToString(), "Model15", 2022, 17000),
            new Bike(Guid.NewGuid().ToString(), "Model16", 2022, 10000),
        };

        public static async Task GetAllBikesPagination(HttpResponse httpResponse, int page, int itemsPerPage)
        {
            try
            {  
                var startIndex = (page - 1) * itemsPerPage;
                var endIndex = startIndex + itemsPerPage;
                var resultBikes = bikes.Skip(startIndex).Take(itemsPerPage);
                await httpResponse.WriteAsJsonAsync(resultBikes);
            }
            catch (Exception ex)
            {
                httpResponse.StatusCode = 500;
                await httpResponse.WriteAsJsonAsync(new { message = ex.Message });
            }
        }

        public static async Task CreateBike(HttpResponse httpResponse, HttpRequest httpRequest)
        {
            try
            {
                Bike bike = await httpRequest.ReadFromJsonAsync<Bike>();
                if (bike != null)
                {
                    bike.Id = Guid.NewGuid().ToString();
                    bikes.Add(bike);
                    await httpResponse.WriteAsJsonAsync(bike);
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

        public static async Task GetBikeById(HttpResponse httpResponse, string id)
        {
            try
            {
                Bike? bike = bikes.FirstOrDefault(x => x.Id == id);
                if (bikes != null)
                {
                    await httpResponse.WriteAsJsonAsync(bike);
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

        public static async Task UpdateBike(HttpResponse httpResponse, HttpRequest httpRequest)
        {
            try
            {
                Bike bike = await httpRequest.ReadFromJsonAsync<Bike>();
                if (bike != null)
                {
                    Bike oldBike = bikes.FirstOrDefault(o => o.Id == bike.Id);
                    if (oldBike != null)
                    {
                        oldBike.Model = bike.Model;
                        oldBike.Year = bike.Year;
                        oldBike.Price = bike.Price;
                        await httpResponse.WriteAsJsonAsync(oldBike);
                        
                    }
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

        public static async Task DeleteBike(string id, HttpResponse httpResponse)
        {
            try
            {
                Bike? bike = bikes.FirstOrDefault((u) => u.Id == id);
                if (bike != null)
                {
                    bikes.Remove(bike);
                    await httpResponse.WriteAsJsonAsync(bike);
                }
                else
                {
                    throw new Exception("Car not found!");
                }
            }
            catch (Exception ex)
            {
                httpResponse.StatusCode = 404;
                await httpResponse.WriteAsJsonAsync(new { message = ex.Message });
            }
        }
    }
}
