using System;
using System.Text;

namespace BandsInTownUWP.Helpers
{
    public class UrlEncodeHelper
    {
        private readonly static string reservedCharacters = "!*'();:@&=+$,/?%#[]";

        //Neither of Uri.EscapeUriString and Uri.EscapeDataString methods encodes 
        //the RFC 2396 unreserved characters If you need these encoded then you 
        //will have to manually encode them
        public static string UrlEncode(string value)
        {
            if (String.IsNullOrEmpty(value))
                return String.Empty;

            var sb = new StringBuilder();

            foreach (char @char in value)
            {
                if (reservedCharacters.IndexOf(@char) == -1)
                    sb.Append(@char);
                else
                    sb.AppendFormat("%{0:X2}", (int)@char);
            }
            return sb.ToString();
        }

    }
}
