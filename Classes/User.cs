namespace ASP
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Work { get; set; }

        public User() : this("", 0, "") { }

        public User(string name, int age, string work)
        {
            Name = name;
            Age = age;
            Work = work;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nWork: {Work}";
        }
    }
}
