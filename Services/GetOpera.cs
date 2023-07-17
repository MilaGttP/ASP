
namespace ASP
{
    public class GetOpera : IGetBrowser
    {
        private int _counter;

        public string GetBrowser(string browseName, bool hasFavicon)
        {
            if (browseName.Equals("Opera"))
            {
                _counter++;
                if (hasFavicon && _counter > 1) _counter--;
            }
            return $"Opera: {_counter}";
        }
    }
}
