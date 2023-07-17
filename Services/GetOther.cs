
namespace ASP
{
    public class GetOther : IGetBrowser
    {
        private int _counter;

        public string GetBrowser(string browseName, bool hasFavicon)
        {
            if (!browseName.Equals("Opera") && !browseName.Equals("Chrome") && !browseName.Equals("FireFox"))
            {
                _counter++;
                if (hasFavicon && _counter > 1) _counter--;
            }
            return $"Other: {_counter}";
        }
    }
}
