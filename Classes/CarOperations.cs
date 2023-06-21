namespace ASP.Classes
{
    public static class CarOperations
    {
        static List<Car> cars = new List<Car>()
        {
            new Car(Guid.NewGuid().ToString(), "Audi", "A8", 2010),
            new Car(Guid.NewGuid().ToString(), "Suzuki", "Vitara", 2014),
            new Car(Guid.NewGuid().ToString(), "BMW", "X5", 2012),
        };
        public static async Task GetAllCars(HttpResponse httpResponse)
        {
            await httpResponse.WriteAsJsonAsync(cars);
        }

        public static async Task CreateCar(HttpResponse httpResponse, HttpRequest httpRequest)
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

        public static async Task GetCarById(HttpResponse httpResponse, string id)
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

        public static async Task UpdateCar(HttpResponse httpResponse, HttpRequest httpRequest)
        {
            try
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

        public static async Task DeleteCar(string id, HttpResponse httpResponse)
        {
            try
            {
                Car? car = cars.FirstOrDefault((u) => u.Id == id);
                if (car != null)
                {
                    cars.Remove(car);
                    await httpResponse.WriteAsJsonAsync(car);
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
