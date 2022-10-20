using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other.Search;

internal class SearcherV4
{
    public IEnumerable<string> Search(string word, IEnumerable<string> data)
    {
        foreach (var item in data)
        {
            int pos = 0;
            while (true)
            {
                pos = item.IndexOf(word, pos);
                if (pos >= 0)
                {
                    yield return PrettyMatch(item, pos);
                }
                else
                    break;
                pos++;
            }
        }
    }

    public string PrettyMatch(string text, int pos)
    {
        var start = Math.Max(0, pos - 50);
        int end = Math.Min(start + 100, text.Length - 1);
        return $"{(start == 0 ? "" : "...")}{text.Substring(start, end - start)}{(end == text.Length - 1 ? "" : "...")}";
    }
}
