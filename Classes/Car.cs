namespace ASP.Classes
{
    public class Car
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car()
        {
            Id = "";
            Brand = "";
            Model = "";
            Year = 0;
        }
        public Car(string id, string brand, string model, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
}