// IMDB API Documentation: https://imdb-api.com/api

using ImdbAPITicketOffice.Lib;
using System.Net;


const string baseURL = "https://imdb-api.com/en/API";
string apiKeyFilePath = Environment.CurrentDirectory + "\\imdbApiKey.txt";
APIKeyFile apiFile = new APIKeyFile(apiKeyFilePath);
if (string.IsNullOrEmpty(apiFile.Key))
{
    Console.WriteLine($"No API Key found. Please enter your IMDB API Key in the file located at: {apiKeyFilePath}");
    Console.WriteLine("Program will not run without API Key. Program will now exit.");
    return;
}
Console.WriteLine("API Key found.");

string result = InTheaters(apiFile);
//Console.WriteLine(result);



string HTTPClientResult(APIKeyFile apiFile, string apiCall)
{
    HttpClient client = new HttpClient();
    var request = client.GetStringAsync($"{baseURL}/{apiCall}/{apiFile.Key}");
    request.Wait();

    return request.Result;
}

string InTheaters(APIKeyFile apiFile)
{
    string result = HTTPClientResult(apiFile, "InTheaters");
    return result;
}

string ComingSoon(APIKeyFile apiFile)
{
    string result = HTTPClientResult(apiFile, "ComingSoon");
    return result;
}