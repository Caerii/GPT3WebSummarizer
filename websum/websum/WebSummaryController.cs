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


        [Route(HttpVerbs.Get, "/gpt/{word}")]
        public async Task<string> Gpt(string word) {
            var result = await new Gpt3Stuff().Run(word);
            return $"Gpt completiton of {word}: {result}";
        }

        // show a web page with the response
        // found at /api/page/mitochondria
        [Route(HttpVerbs.Get, "/page/{word}")]
        public string SumPage(string word) {
            var webpage = new WebTemplater().GetPage("answer", "Summary", $"this is a summary of {word}"); ;

            // TODO: doesn't work, need to write to HttpContext.Response i guess
            HttpContext.Response.ContentType = "text/html"; 
            HttpContext.Response.ContentEncoding = Encoding.UTF8;
            return webpage;
            
        }
    }
}
