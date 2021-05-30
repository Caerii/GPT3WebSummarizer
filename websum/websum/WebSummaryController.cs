using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace websum {
    class WebSummaryController : WebApiController {

        // found at /api/time
        [Route(HttpVerbs.Get, "/time")]
        public string TimeNow() {
            return "Zulu time is " + DateTime.UtcNow.ToString();
        }

        [Route(HttpVerbs.Get, "/sum/{word}")]
        public string Sum(string word) {
            return $"Summary of {word}: ";
        }

        // found at /api/gpt/mitochondria
        [Route(HttpVerbs.Get, "/gpt/{word}")]
        public async Task<string[]> Gpt(string word) {
            var result = await new Gpt3Stuff().Run(word);
            //return $"Gpt completiton of {word}: {result}";
            return new string[] { $"{word}{result}" }; // json-ish
            //await HttpContext.SendStringAsync($"{word}{result}", "text/plain", Encoding.UTF8);
        }


        // TODO: fix crash
        // show a web page with the response
        // found at /api/page/synchrotron
        [Route(HttpVerbs.Get, "/page/{word}")]
        public async void SumPage(string word) {

            var result = await new Gpt3Stuff().Run(word);
            var webpage = new WebTemplater().GetPage("answer", "{word}", $"this is a summary of {word}:<br/>{result}"); ;

            //error: Cannot access a disposed object
            await HttpContext.SendStringAsync(webpage, "text/html", Encoding.UTF8);
        }


        // show a web page with a test response
        // found at /api/testpage/synchrotron
        [Route(HttpVerbs.Get, "/testpage/{word}")]
        public async void TestPage(string word) {
            var webpage = new WebTemplater().GetPage("test page", "Summary", $"this is a test page about {word}"); ;
            await HttpContext.SendStringAsync(webpage, "text/html", Encoding.UTF8);
        }
    }
}
