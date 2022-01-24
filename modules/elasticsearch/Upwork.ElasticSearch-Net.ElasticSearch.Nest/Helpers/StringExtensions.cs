using System.Text;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest.Helpers { 

public static class StringExtensions {
    public static string Sanitize(this string str) {
        var sb = new StringBuilder();
        str = str.Trim().ToLowerInvariant();

        foreach (char c in str) {
            if (!char.IsSymbol(c)) sb.Append(c);
        }

        return sb.ToString();
    }
}
}