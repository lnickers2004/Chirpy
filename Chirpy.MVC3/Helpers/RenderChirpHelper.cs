using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chirpy.Domain.Model;
using System.Net;

namespace Chirpy.Helpers
{
    public static class RenderChirpHelper
    {
        public static IHtmlString RenderChirp(this HtmlHelper html, Chirp chirp)
        {
            string result = WebUtility.HtmlEncode(chirp.Value);

            //TODO Implement better RegEx matching http://stackoverflow.com/a/5367564/431891
            string[] tokens = chirp.Value.Split(new char[] { ' ' });
            for (int tokenCount = 0; tokenCount < tokens.Length; tokenCount++)
            {
                if (tokens[tokenCount].StartsWith("#"))
                {
                    var encodedToken = WebUtility.HtmlEncode(tokens[tokenCount]);
                    result = result.Replace(encodedToken, "<a href=\"\">" + encodedToken + "</a>");
                }
            }
            return new MvcHtmlString(result);
        }
    }
}