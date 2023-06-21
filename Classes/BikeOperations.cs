namespace ASP.Classes
{
    public static class BikeOperations
    {
        static List<Bike> bikes = new List<Bike>()
        {
            new Bike(Guid.NewGuid().ToString(), "Model1", 2021, 9000),
            new Bike(Guid.NewGuid().ToString(), "Model2", 2022, 10000)
        };

        public static async Task GetAllBikes(HttpResponse httpResponse)
        {
            await httpResponse.WriteAsJsonAsync(bikes);
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
                    await httpResponse.WriteAsJsonAsync(bikes);
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
