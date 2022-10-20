using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other.Search;

internal static class Utils
{
    public static IEnumerable<string> GetTestData()
    {
        return ReadDocument(AppContext.BaseDirectory + "data.txt");
    }

    private static IEnumerable<string> ReadDocument(string fileName)
    {
        using (var streamReader = new StreamReader(fileName))
            while (!streamReader.EndOfStream)
            {
                var doc = streamReader.ReadLine()?.Split('\t');
                yield return doc[1];
            }
    }
}
