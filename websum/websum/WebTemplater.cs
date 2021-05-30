using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace websum {
    class WebTemplater {

        
        public string GetPage(string page, string title, string body) {
            string p = File.ReadAllText($"www-root/{page}.html");
            return p.Replace("{title}", title).Replace("{body}", body);
        }
    }
}
