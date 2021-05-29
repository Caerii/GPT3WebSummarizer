using System;
using System.Collections.Generic;
using System.Text;
using OpenAI_API;

namespace websum {
    public class Gpt3Stuff {

        public Gpt3Stuff() {
            string apipath = @"Z:\openai.txt";
            OpenAI_API.APIAuthentication.LoadFromPath(apipath);
        }

        public async void Run(string text = "One Two Three One Two") {

            // https://github.com/OkGoDoIt/OpenAI-API-dotnet

            var api = new OpenAI_API.OpenAIAPI(engine: Engine.Davinci);

            var req = new CompletionRequest(text, temperature: 0.1);

            // log req

            var result1 = await api.Completions.CreateCompletionAsync(req);
            //var result2 = await api.Completions.CreateCompletionAsync(text, temperature: 0.1);


            Console.WriteLine(result1.ToString());
            // should print something starting with "Three"
        }
    }
}
