
namespace ASP
{
    public class GetChrome : IGetBrowser
    {
        private int _counter;

        public string GetBrowser(string browseName, bool hasFavicon)
        {
            if (browseName.Equals("Chrome"))
            {
                _counter++;
                if (hasFavicon && _counter > 1) _counter--;
            }
            return $"Chrome: {_counter}";
        }
    }
}
