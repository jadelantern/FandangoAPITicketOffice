// fandango API Documentation: https://developer.fandango.com/io-docs

using FandangoAPITicketOffice.Lib;

string apiKeyFilePath = Environment.CurrentDirectory + "\\fandangoApiKey.txt";
APIKeyFile apikey = new APIKeyFile(apiKeyFilePath);
Console.WriteLine(apikey.Key);

apikey.Key = "Hello World";