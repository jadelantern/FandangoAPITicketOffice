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
Console.WriteLine("API Key found.");

string result = api.InTheaters();
Console.WriteLine(result);
Console.WriteLine("\n\n");

var inTheatersData = api.InTheaters2();
string title = inTheatersData.Items[0].FullTitle;

Console.WriteLine(title);