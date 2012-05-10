using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Chirpy.Domain.Model
{
    public class Chirp
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Chirp InReplyTo { get; set; }
        public IList<Chirp> Replies { get; set; }
        public IList<ChirpTag> Tags { get; set; }
        public ChirpyUser User;
        public Chirp()
        {
            Tags = new List<ChirpTag>();
            User = new ChirpyUser();
        }

        public string ToHtml()
        {
            string result = WebUtility.HtmlEncode(this.Value);

            //TODO Implement better RegEx matching http://stackoverflow.com/a/5367564/431891
            string[] tokens = this.Value.Split(new char[] { ' ' });
            for (int tokenCount = 0; tokenCount < tokens.Length; tokenCount++)
            {
                if (tokens[tokenCount].StartsWith("#"))
                {
                    var encodedToken = WebUtility.HtmlEncode(tokens[tokenCount]);
                    result = result.Replace(encodedToken, "<a href=\"\">" + encodedToken + "</a>");
                }
            }
            return result;
        }
    }
}
