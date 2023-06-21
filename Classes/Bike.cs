namespace ASP.Classes
{
    public class Bike
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public Bike()
        {
            Id = "";
            Model = "";
            Year = 0;
            Price = 0;
        }
        public Bike(string id, string model, int year, int price)
        {
            Id = id;
            Model = model;
            Year = year;
            Price = price;
        }
    }

}
