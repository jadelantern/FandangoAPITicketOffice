// IMDB API Documentation: https://imdb-api.com/api

using ImdbAPITicketOffice.Lib;
using System.Net;




if (string.IsNullOrEmpty(apiFile.Key))
{
    Console.WriteLine($"No API Key found. Please enter your IMDB API Key in the file located at: {apiKeyFilePath}");
    Console.WriteLine("Program will not run without API Key. Program will now exit.");
    return;
}
Console.WriteLine("API Key found.");

string apiKeyFilePath = Environment.CurrentDirectory + "\\imdbApiKey.txt";
ImdbApi api = new ImdbApi(apiKeyFilePath);
string result = InTheaters(apiFile);
//Console.WriteLine(result);



