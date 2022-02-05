using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbAPITicketOffice.Lib
{
    public class ImdbApi
    {
        /// <summary>
        /// The base url for the entire project. Used for every API call.
        /// </summary>
        public const string baseURL = "https://imdb-api.com/en/API";
        public APIKeyFile apiFile;
        
        public ImdbApi(string apiKeyFilePath)
        {
            apiFile = new APIKeyFile(apiKeyFilePath);
        }

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
    }
}
