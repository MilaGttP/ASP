
namespace ASP
{
    public class Quote
    {
        public string quote { get; set; }
        public string author { get; set; }
        public string category { get; set; }

        public Quote() : this("", "", "") { }

        public Quote(string quote, string author, string category)
        {
            this.quote = quote;
            this.author = author;
            this.category = category;
        }

        public override string ToString()
        {
            return $"Quote: {quote}\nAuthor: {author}\nCategory: {category}";
        }
    }
}
