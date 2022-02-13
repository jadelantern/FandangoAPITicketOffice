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

        public string HTTPClientResult(string apiCall)
        {
            HttpClient client = new HttpClient();
            var request = client.GetStringAsync($"{baseURL}/{apiCall}/{apiFile.Key}");
            request.Wait();

            return request.Result;
        }

        public string InTheaters()
        {
            string result = HTTPClientResult("InTheaters");
            return result;
        }

        public InTheatersJson InTheaters2()
        {
            string json = HTTPClientResult("InTheaters");
            var testJson = InTheatersJson.FromJson(json);
            return testJson;
        }

        public string ComingSoon()
        {
            string result = HTTPClientResult("ComingSoon");
            return result;
        }
    }
}
