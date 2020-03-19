using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        private static readonly string _serverAdress = "http://localhost:5000";
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri(_serverAdress) };
        static async Task Main(string[] args)
        {
            var testTextTable = new[] { "jashnjdnas", "ajsbdib", "aisbdiagb", "ashbdiasi", "jdsbhi", "hgedbfgb", "632487298", "hiasuhdiuh" };
            
            var loopCount=0;

            for (var i = 0; i < testTextTable.Length; i++)
            {
                var endpoint1 = $"{_serverAdress}/File/SaveSomeText?={testTextTable[i]}";
                var endpoint2 = $"{_serverAdress}/File/SaveSomeText2?={testTextTable[i]}";
                
                if (i % 2 == 0)
                {
                    if (!await PostToApi(endpoint1,"")) continue;
                    loopCount = DisplayInfo(loopCount, testTextTable.Length,nameof(endpoint1));
                }
                else
                {
                    if (!await PostToApi(endpoint2, "")) continue;
                    loopCount = DisplayInfo(loopCount, testTextTable.Length,nameof(endpoint2));
                }
            }
            Console.ReadLine();
        }

        private static int DisplayInfo(int loopCount, int testTextTableLength, string endpointName)
        {
            loopCount++;
            Console.WriteLine($"Invoke {endpointName}. Finished {loopCount} from {testTextTableLength}");
            return loopCount;
        }

        private static async Task<bool> PostToApi(string endpoint, string text)
        {
            var result = await Client.PostAsync(endpoint, new StringContent(text, Encoding.UTF8));
            return result.IsSuccessStatusCode;
        }
    }
}
