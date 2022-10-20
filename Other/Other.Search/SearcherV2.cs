using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other.Search;

internal class SearcherV2
{
    public void Search(string word, IEnumerable<string> data)
    {
        foreach (var item in data)
        {
            if (item.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                Console.WriteLine(PrettyMatch(word, item));
        }
    }
    private string PrettyMatch(string word, string text)
    {
        int pos = text.IndexOf(word);
        var start = Math.Max(0, pos - 50);//Проверка на выход за границы
        int end = Math.Min(start + 100, text.Length - 1);
        return $"{(start == 0 ? "" : "...")}{text.Substring(start, end - start)}{(end == text.Length - 1 ? "" : "...")}";
    }
}
