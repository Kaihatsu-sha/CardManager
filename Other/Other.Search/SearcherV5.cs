using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other.Search;

internal class SearcherV5
{

    private readonly Dictionary<string, HashSet<int>> _index = new Dictionary<string, HashSet<int>>();
    private readonly List<string> _content = new List<string>();
    private readonly Lexer _lexer = new Lexer();

    /// <summary>
    /// Добавляем все слова в "индекс"
    /// </summary>
    /// <param name="text"></param>
    public void AddStringToIndex(string text)
    {
        int documentId = _content.Count;
        foreach (var token in _lexer.GetTokens(text))
        {
            if (_index.TryGetValue(token, out var set))
                set.Add(documentId);
            else

                _index.Add(token, new HashSet<int>() { documentId });
        }
        _content.Add(text);
    }


    public IEnumerable<int> Search(string word)
    {
        word = word.ToLowerInvariant();
        if (_index.TryGetValue(word, out var set))
            return set;
        return Enumerable.Empty<int>();
    }

}

public class Lexer
{
    /// <summary>
    /// Извлекаем слова
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public IEnumerable<string> GetTokens(string text)
    {
        int start = -1;

        for (int i = 0; i < text.Length; i++)
        {

            if (char.IsLetterOrDigit(text[i]))
            {
                if (start == -1)
                    start = i;
            }
            else
            {
                if (start >= 0)
                {
                    yield return GetToken(text, i, start);
                    start = -1;
                }
            }

        }
    }

    private string GetToken(string text, int i, int start)
    {
        return text.Substring(start, i - start).Normalize().ToLowerInvariant();
    }
}