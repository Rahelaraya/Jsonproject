using Jsonproject;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static Jsonproject.Infodata;
using static System.Reflection.Metadata.BlobBuilder;

string DataJSONfilePath = "LibraryData.json";
string AllDataAsJSONType = File.ReadAllText(DataJSONfilePath);

Infodata infodata = JsonSerializer.Deserialize<Infodata>(AllDataAsJSONType)!;
BibData bibData = new BibData();





bool runing = true;

while (runing)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Lägg till ny bok:");
    Console.WriteLine("2. Lägg till ny författare:");
    Console.WriteLine("3. Uppdatera bokdetaljer:");
    Console.WriteLine("4. Uppdatera författardetaljer:");
    Console.WriteLine("5. Ta bort bok:");
    Console.WriteLine("6. Ta bort författare:");
    Console.WriteLine("7. Lista alla böcker och författare:");
    Console.WriteLine("8. Sortera alla böcker och författare:");
    Console.WriteLine("9. Sök och filtrera böcker:");
    Console.WriteLine("10. Rating böcker:");
    Console.WriteLine("11.Spara och Avsluta:");
    Console.Write("Enter your choice:");
    
    if (!int.TryParse(Console.ReadLine(), out int chooseMenuOptionstring))
    {
        Console.WriteLine("Ange ett giltigt nummer.");
        return;
    }

    int chooseMenuOption = Convert.ToInt32(chooseMenuOptionstring);
    switch (chooseMenuOption)
    {
        case 1:

            bibData.AddnewBooks(infodata);

            

            break;
        case 2:
           bibData.AddnewAuthors(infodata);

            break;

        case 3:
            bibData.UpdateBooksDetail(infodata);

            break;
        case 4:
             bibData.UpdateAuthorsDetail(infodata);

            break;
        case 5:
           bibData.DeleteBooks(infodata);

            break;
        case 6:
           bibData.DeleteAuthors(infodata);
            break;
        case 7:
            bibData.ListaavBooksAuthors(infodata);
            break;
        case 8:
           bibData.Sorteraalla(infodata);
            break;
        case 9:

            bibData.Filter(infodata);

            break;

        case 10:
            bibData.Reviews(infodata);

            break;
        case 11:

            bibData.SaveAllData(infodata);
            return;
        default:
                Console.WriteLine("Ogiltigt val. Försök igen!");
          break;


    }
      
}

