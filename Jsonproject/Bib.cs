using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Jsonproject
{
    public class BibData

    {
        public void AddnewBooks(Infodata infodata)
        {
            Console.WriteLine("Ange Bokens Titel:");
            string BooksTitle = Console.ReadLine()!;

            Console.WriteLine("Ange Författarens Namn:");
            string BooksAuthor = Console.ReadLine()!;

            Console.WriteLine("Ange genre:");
            string BooksGenre = Console.ReadLine()!;

            Console.WriteLine("Ange Publicerat år");
            if (!int.TryParse(Console.ReadLine(), out int BooksPublishedYear))
            {
                Console.WriteLine("Ogiltig inmatning för publiceringsår. Ange ett giltigt nummer.");
                return;
            }
            Console.WriteLine("Ange ISBN:");
            if (!int.TryParse(Console.ReadLine(), out int BooksISBN))
            {
                Console.WriteLine("Ogiltig inmatning för ISBN. Ange ett giltigt nummer.");
                return;
            }
            var existingBooks = infodata.AllBooksJson.FirstOrDefault(Books => Books.Title.Equals(BooksTitle, StringComparison.OrdinalIgnoreCase));
            if (existingBooks != null)
            {
                Console.WriteLine($"Författaren finns redan i systemet: {existingBooks.Title}");
                return;
            }
            else
            {
                Books newBook = new Books(BooksTitle, BooksAuthor, BooksGenre, BooksPublishedYear, BooksISBN, []);
                infodata.AllBooksJson.Add(newBook);

                Console.WriteLine($"Läggde till författare: Books Title: {BooksTitle}, Books Author: {BooksAuthor}, Books Genre: {BooksGenre}, Books Published Year:{BooksPublishedYear},Books ISBN: {BooksISBN}");

            }
            SaveAllData(infodata);
        }
        public void AddnewAuthors(Infodata infodata)
        {
            Console.WriteLine("ID");         
            if (!int.TryParse(Console.ReadLine(), out int AuthorId))
            {
                Console.WriteLine("Ogiltig inmatning för BooksId . Ange ett giltigt nummer.");
                return;
            }
            
            Console.WriteLine("Ange författarens Namn:");
            string AuthorsName = Console.ReadLine()!;
            Console.WriteLine("Ange författarens Land:");
            string AuthorsCountry = Console.ReadLine()!;
            Console.WriteLine("Ange författarens Bokar:");
            string AuthorsBook = Console.ReadLine()!;
            Console.WriteLine("Ange författarens Språk:");
            string AuthorsLanguage = Console.ReadLine()!;

            var existingAuthor = infodata.AllAuthorsJson.FirstOrDefault(author => author.Name.Equals(AuthorsName, StringComparison.OrdinalIgnoreCase));

            if (existingAuthor != null)
            {
                Console.WriteLine($"Författaren finns redan i systemet: {existingAuthor.Name}");
                return;
            }
            else
            {
                Authors newAuthor = new Authors(AuthorId, AuthorsName, AuthorsCountry, AuthorsBook, AuthorsLanguage);
                infodata.AllAuthorsJson.Add(newAuthor);
                Console.WriteLine($"Läggde till författare: Titel: {AuthorsName}, Bok: {AuthorsBook}, Språk: {AuthorsLanguage}");
            }
            SaveAllData(infodata);
        }
        public void UpdateBooksDetail(Infodata infodata)
        {
            Console.WriteLine("Ange boks Id som du vill Uppdatera:");
            if (!int.TryParse(Console.ReadLine(), out int BooksId))
            {
                Console.WriteLine("Ogiltig inmatning för BooksId . Ange ett giltigt nummer.");
                return;
            }
            var Uppdaterabokdetaljer = infodata.AllBooksJson.FirstOrDefault(book => book.Id.Equals(BooksId));

            if (Uppdaterabokdetaljer == null)
            {
                Console.WriteLine($"Bok {BooksId} finns inte i listan.");
                return;
            }
            else
            {
                Console.Write("Ange Bok Title:");
                string BookTitle = Console.ReadLine()!;
                Console.Write("Ange BokAuthor:");
                string BookAuthor = Console.ReadLine()!;
                Console.Write("Ange Bok Genre:");
                string BookGenre = Console.ReadLine()!;
                Console.Write("Ange Bok ISBN:");
                if (!int.TryParse(Console.ReadLine(), out int BookISBN))
                {
                    Console.WriteLine("Ogiltig inmatning för BookISBN . Ange ett giltigt nummer.");
                    return;
                }
                Console.WriteLine("nge Publicerat år: ");
                if (!int.TryParse(Console.ReadLine(), out int BookPublishedYear))
                {
                    Console.WriteLine("Ogiltig inmatning för BookPublishedYea. Ange ett giltigt nummer.");
                    return;
                }
              
                Books newBook = new Books(BookTitle, BookAuthor, BookGenre, BookPublishedYear, BookISBN, []);


                Console.WriteLine($"Uppdatera bokdetaljer: Title:{BookTitle}, Author: {BookAuthor}, Genre: {BookGenre},ISBN: {BookISBN}, Books Published Year: {BookPublishedYear}");
            }
            SaveAllData(infodata);
        }
        public void UpdateAuthorsDetail(Infodata infodata)
        {
            Console.WriteLine("Ange författarens Id som du vill Uppdatera:");
            if (!int.TryParse(Console.ReadLine(), out int AuthorsId))
            {
                Console.WriteLine("Ogiltig inmatning för AuthorsId. Ange ett giltigt nummer.");
                return;
            }

            var Uppdaterauthordetails = infodata.AllAuthorsJson.FirstOrDefault(author => author.Id.Equals(AuthorsId));

            if (Uppdaterauthordetails == null)
            {
                Console.WriteLine($"Författaren {AuthorsId} finns inte i listan.");
                return;
            }
            else
            {
                Console.WriteLine("Ange författarens Namn:");
                string AuthorName = Console.ReadLine()!;
                Console.Write("Ange författarens land: ");
                string Authorcountry = Console.ReadLine()!;
                Console.Write("Ange boktitel: ");
                string bookTitle = Console.ReadLine()!;
                Console.Write("Ange författarens språk: ");
                string Authorlanguage = Console.ReadLine()!;

                Authors newAuthor = new Authors(AuthorsId, AuthorName, Authorcountry, bookTitle, Authorlanguage);
                Console.WriteLine($"Uppdatera författardetaljer: Name: {AuthorName} Titel: {bookTitle}, Land: {Authorcountry}, Språk: {Authorlanguage}");
            }
            SaveAllData(infodata);
        }
        public void DeleteBooks(Infodata infodata)
        {
            Console.WriteLine("Ange boks ID som du vill ta bort bok:");

            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Ogiltig inmatning för bookId. Ange ett giltigt nummer.");
                return;
            }


            bool bookFound = false;
            var bookToDelete = infodata.AllBooksJson.FirstOrDefault(b => b.Id == bookId);

            if (bookToDelete == null)
            {
                Console.WriteLine("Boken hittades inte.");
            }
            else
            {
                Console.WriteLine($"----{bookToDelete.Title} har tagits bort.\n");
                bookFound = true;
            }
            SaveAllData(infodata);
            return;
        }
        public void DeleteAuthors(Infodata infodata)
        {
            Console.WriteLine("Ange Author ID som du vill ta bort bok:");
           
            if (!int.TryParse(Console.ReadLine(), out int AuthorToDeleteId)) 
            {
                Console.WriteLine("Ogiltig inmatning för AuthorsId. Ange ett giltigt nummer.");
                return;
            }

            bool Authorfound = false;
            var AuthorToDelete = infodata.AllAuthorsJson.FirstOrDefault(b => b.Id == AuthorToDeleteId);

            if (AuthorToDelete == null)
            {
                Console.WriteLine("Author hittades inte.");
            }
            else
            {
                Console.WriteLine($"{AuthorToDelete.Name} har tagits bort.\n");
                Authorfound = true;
            }
            SaveAllData(infodata);
        }
       public void ListaavBooksAuthors(Infodata infodata)
        {
            Console.WriteLine("Lista av Books:");


            foreach (var book in infodata.AllBooksJson)
            {
                Console.WriteLine($" {book.Id}:av {book.Author}, Title: {book.Title}, Genre: {book.Genre},publicerings år:{book.PublishedYear}");
            }

            Console.WriteLine("\n Lista av Authors:");
            foreach (var author in infodata.AllAuthorsJson)
            {
                Console.WriteLine($"{author.Id}: av {author.Name} från: {author.Country}, Språk: {author.Language}");

            }
           
        }
        public void Sorteraalla(Infodata infodata)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("1.Sortera böcker efter Authors Name:");
            Console.WriteLine("2 Sortera böcker efter Titel:");
            Console.WriteLine("3.Sortera böcker efter publicerings år:");
            Console.Write("Enter your choice:");
            
            if (!int.TryParse(Console.ReadLine(), out int andravalstr))
            {
                Console.WriteLine(" Ange ett giltigt nummer.");
                return;
            }
            int andraval = Convert.ToInt32(andravalstr);
            switch (andraval)
            {
                case 1:

                    var sortedBooks = infodata.AllBooksJson.OrderBy(book => book.Author).ToList();

                    foreach (var book in sortedBooks)
                    {

                        Console.WriteLine($" {book.Author}");
                    }

                    break;
                case 2:
                    var sortedBook = infodata.AllBooksJson.OrderBy(book => book.Title).ToList();
                    foreach (var book in sortedBook)
                    {
                        Console.WriteLine($" {book.Title}");
                    }

                    break;
                case 3:
                    var sortedBooker = infodata.AllBooksJson.OrderBy(book => book.PublishedYear).ToList();
                    foreach (var book in sortedBooker)
                    {
                        Console.WriteLine($" {book.PublishedYear}");
                    }
                    break;
            }
            
        }
       public void Filter(Infodata infodata)
        {
            Console.WriteLine("----------");
            Console.WriteLine("1. Sök och filtrera Bok Author:");
            Console.WriteLine("2. Sök och filtrera Genre:");
            Console.WriteLine("3. Sök och filtrera  publicerings år:");
            Console.Write("Enter your choice:");
            if (!int.TryParse(Console.ReadLine(),out int secondMenuOptionstr))
            {
                Console.WriteLine("Ange ett giltigt nummer.");
                return;
            }
            int secondMenuOption = Convert.ToInt32(secondMenuOptionstr);

            IEnumerable<Books> booksfilter = infodata.AllBooksJson;

            switch (secondMenuOption)
            {
                case 1:
                    string author = Prompt("Ange bok author:");
                    booksfilter = infodata.AllBooksJson.Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
                    displey(booksfilter);


                    break;
                case 2:

                    string genre = Prompt("Ange Genre: ");
                    booksfilter = infodata.AllBooksJson.Where(book => book.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
                    displey(booksfilter);
                    break;
                case 3:
                    int year = int.Parse(Prompt("Enter publiched Year "));
                    booksfilter = infodata.AllBooksJson.Where(book => book.PublishedYear == year);
                    displey(booksfilter);
                    break;

            }
           
        }
        public void Reviews(Infodata infodata)
        {
            Console.WriteLine("Ange bokId för Rating:");
           

            if (int.TryParse(Console.ReadLine(), out int addreviewToBook))

            {
                var book = infodata.AllBooksJson.FirstOrDefault(book => book.Id == addreviewToBook);
                if (book != null)
                {
                    Console.WriteLine("enter rating between 1 - 5 :");
                    if (int.TryParse(Console.ReadLine(), out int reviews))
                    {

                        book.AddReviews(reviews);

                    }
                    else
                    {
                        Console.WriteLine("Ange data måste vara number.");

                    }


                }
                else
                {
                    Console.WriteLine(" Boken hittas inte. ");
                }

            }
            SaveAllData(infodata);
        }
       
        private static void DisplayFiltringBooks(IEnumerable<Books> booksfilter)
        {
            Console.WriteLine("\nBooks: ");
            foreach (var book in booksfilter)
                Console.WriteLine($" {book.Title} by {book.Author} , {book.Genre}\n");

        }
       public void displey(IEnumerable<Books> booksfilter)
       {
            Console.WriteLine("\nBooks: ");
            foreach (var book in booksfilter)
            Console.WriteLine($" {book.Title} by {book.Author} , {book.Genre}, {book.PublishedYear}\n");
       }
        
        string Prompt(string message, string defaultValue = "")
        {
            Console.WriteLine(message);
            string input = Console.ReadLine()!;
            return string.IsNullOrEmpty(input) ? defaultValue : input;
        }

       
        public void SaveAllData(Infodata infodata)
        {
            string dataJsonFilePath = "LibraryData.json";
            string jsonData = JsonSerializer.Serialize(infodata, new JsonSerializerOptions { WriteIndented = true });

            if (File.Exists(dataJsonFilePath))
            {

                File.AppendAllText(dataJsonFilePath, Environment.NewLine + jsonData);

                Console.WriteLine("All data har sparats.");
            }
            else
            {
                Console.WriteLine($"Ett fel uppstod när data sparades");
            }
            
        }


    }
}
