using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dugun.Common
{
    public static class MetaUtils
    {
 
    }

    public class HeaderItem
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Keywords { get; set; }
        
        public string ImageSrc { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return

            //General
            "<title>" + Title + " &middot; Osmantimurtas.com.tr</title>\n" +
            "<meta name=\"description\" content=\"" + Description.MaxString(160) + "\" />\n" +
            "<meta name=\"keywords\" content=\"" + Keywords.MaxString(260) + "\" />\n" +
            "<link rel=\"image_src\" href=\"" + ImageSrc + " \">\n" +

            //Twitter
            "<meta name=\"twitter:card\" content=\"Osman Timurtaş\">" + 
            "<meta name=\"twitter:url\" content=\"" + HttpContext.Current.Request.Url.AbsoluteUri + "\"" + Url + " >" +
            "<meta name=\"twitter:title\" content=\"" + Title + "\">\n" +
            "<meta name=\"twitter:description\" content=\"" + Description.MaxString(160) + "\">\n" +
            "<meta name=\"twitter:image:src\" content=\"" + ImageSrc + "\">\n" +
            
            //Facebook
            "<meta property=\"og:title\" content=\"" + Title + "\" />\n" +
            "<meta property=\"og:type\" content=\"article\" />\n" +
            "<meta property=\"og:image\" content=\"" + ImageSrc + "\" />\n" +
            "<meta property=\"og:url\" content=\"" + HttpContext.Current.Request.Url.AbsoluteUri + "\"" + Url + " />\n" +
            "<meta property=\"og:description\" content=\"" + Description.MaxString(160) + "\" />\n" +
            "<meta property=\"og:locale\" content=\"tr-TR\" />\n" +
            "<meta property=\"og:locale:alternate\" content=\"en_US\" />\n";
        }
    }
}