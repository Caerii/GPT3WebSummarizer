using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenAI_API;

namespace websum {
    public class Gpt3Stuff {

        public Gpt3Stuff() {
            
        }

        public async Task<string> Run(string text = "One Two Three One Two") {

            // https://github.com/OkGoDoIt/OpenAI-API-dotnet

            string apipath = @"openai.txt";
            var auth = APIAuthentication.LoadFromPath(filename: apipath);
            var api = new OpenAIAPI(apiKeys: auth, engine: Engine.Davinci);
           

            var req = new CompletionRequest(text, temperature: 0.5, max_tokens: 10);

            // TODO: log/cache req

            var result1 = await api.Completions.CreateCompletionAsync(req);

            return result1.ToString(); // e.g. should be something starting with "Three"
        }
    }
}
