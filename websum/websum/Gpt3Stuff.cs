using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OpenAI_API;

namespace websum {
    public class Gpt3Stuff {

        public Gpt3Stuff() {
            
        }

        public OpenAIAPI GetApi() {
            // put your key in a text file "C:\Users\pengo\.openai" or "~/.openai"
            string file = @".openai";
            var apikeypath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), file);
            string apikey = null;
            try {
                apikey = File.ReadAllText(apikeypath).Trim();
            } catch (Exception e) {
                Console.WriteLine("Couldn't read auth; error: " + e.Message);
                Console.WriteLine($"Make a file containing api key at: {apikeypath}");
            }
            //var auth = APIAuthentication.LoadFromPath() // couldn't get this to work idk
            var api = new OpenAIAPI(apiKeys: apikey, engine: Engine.Davinci);
            return api;
        }

        public async Task<string> Run(string text = "One Two Three One Two") {

            // https://github.com/OkGoDoIt/OpenAI-API-dotnet

            var api = GetApi();

            var req = new CompletionRequest(text, temperature: 0.5, max_tokens: 10);

            // TODO: log/cache req

            var result1 = await api.Completions.CreateCompletionAsync(req);

            return result1.ToString(); // e.g. should be something starting with "Three"
        }
    }
}
