using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;

using System;
using System.Collections.Generic;
using System.Text;

namespace websum {
    class WebSummaryController : WebApiController {

        // /api/sum
        [Route(HttpVerbs.Get, "/sum")]
        public string TableTennis() {
            return "pong";
        }
    }
}
