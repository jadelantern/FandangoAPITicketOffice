// IMDB API Documentation: https://imdb-api.com/api

using ImdbAPITicketOffice.Lib;
using System.Net;

string apiKeyFilePath = Environment.CurrentDirectory + "\\imdbApiKey.txt";
ImdbApi api = new ImdbApi(apiKeyFilePath);


if (string.IsNullOrEmpty(api.apiFile.Key))
{
    Console.WriteLine($"No API Key found. Please enter your IMDB API Key in the file located at: {apiKeyFilePath}");
    Console.WriteLine("Program will not run without API Key. Program will now exit.");
    return;
}
Console.WriteLine("IMDB API Key found. Please wait while we contact the database...");
var inTheatersData = await api.InTheaters();

Console.WriteLine("\n\nWelcome to the ticket office... These are the movies that are currently in theaters:");

// Call GetAllMovieTitles().
// Store the results
// Pass the results into ShowAllMovieTitles()
var movieTitles = GetAllMovieTitles(inTheatersData);
if (!movieTitles.Any())
{
    Console.WriteLine("Sorry there are no new movies this week... try again next week.");
    return;
}

ShowAllMovieTitles(movieTitles);

Console.WriteLine("\nWhich movie would you like a ticket for: ");
var ticketName = Console.ReadLine();

bool isTicketValid = DoesMovieExist(movieTitles, ticketName);
if (isTicketValid)
{
    Console.WriteLine("Your ticket was found!");
}
else
{
    Console.WriteLine("Ticket not found");
}



bool DoesMovieExist(List<string> movietitle, string ticketName)
{
    foreach (var title in movieTitles)
    {
        if (ticketName.ToLower() != title.ToLower())
            continue;

        return true;
    }

    return false;
}

void ShowAllMovieTitles(List<string> movieTitles)
{
    // Will show all movie titles.
    foreach (var item in movieTitles)
    {
        Console.WriteLine($"\n{item}");
    }
}

List<string> GetAllMovieTitles(InTheatersJson jsonMovieList)
{
    var movieTitles = new List<string>();
    foreach (var item in jsonMovieList.Items)
    {
        movieTitles.Add(item.Title);
    }
    return movieTitles;
}