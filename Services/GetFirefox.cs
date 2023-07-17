
namespace ASP
{
    public class GetFirefox : IGetBrowser
    {
        private int _counter;

        public string GetBrowser(string browseName, bool hasFavicon)
        {
            if (browseName.Equals("Firefox"))
            {
                _counter++;
                if (hasFavicon && _counter > 1) _counter--;
            }
            return $"Firefox: {_counter}";
        }
    }
}
