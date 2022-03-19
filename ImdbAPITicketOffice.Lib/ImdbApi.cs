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

        public async Task<string> HTTPClientResult(string apiCall)
        {
            HttpClient client = new HttpClient();
            var JSON = await client.GetStringAsync($"{baseURL}/{apiCall}/{apiFile.Key}");

            return JSON;
        }

        public async Task<InTheatersJson> InTheaters()
        {
            string json = await HTTPClientResult("InTheaters");
            var testJson = InTheatersJson.FromJson(json);
            return testJson;
        }

        public async Task<string> ComingSoon()
        {
            string result = await HTTPClientResult("ComingSoon");
            return result;
        }
    }
}
