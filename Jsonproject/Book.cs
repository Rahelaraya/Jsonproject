
namespace Jsonproject
{
  public class Books
  {       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public int PublishedYear { get; set; }

        public Books(string title, string author, string genre, int iSBN,int publishedYear, List<int> reviews)
        {
                Title = title;
                Author = author;
                Genre = genre;
                ISBN = iSBN;
                PublishedYear = publishedYear;
                Reviews = reviews;

        }
        public List<int> Reviews { get; set; } = new List<int>();
        public void AddReviews(int reviews)
        {

            if (reviews >= 1 && reviews <= 5)
            {
                Reviews.Add(reviews);
                Console.WriteLine($"Rating {reviews} lagt till i boken {Title} ");
            }

            else
            {
                Console.WriteLine("Ange data måste vara mellan 1-5");
            }
            
        }

    }
}
