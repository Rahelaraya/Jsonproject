

namespace Jsonproject
{
    public class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Book { get; set; }
        public string Language { get; set; }
        
        public Authors(int id, string name, string country, string book, string language)
        {
            Id = id;
            Name = name;
            Country = country;
            Language = language;
            Book = book;
          
        }
    }
}
