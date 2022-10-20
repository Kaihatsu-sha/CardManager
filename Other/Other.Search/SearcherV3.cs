using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other.Search;

internal class SearcherV3
{
    public void Search(string word, IEnumerable<string> data)
    {
        foreach (var item in data)
        {
            Console.WriteLine("==============");
            int pos = 0;
            while (true)
            {
                pos = item.IndexOf(word, pos);
                if (pos >= 0)
                {
                    Console.WriteLine(PrettyMatch(item, pos));
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
