using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other.Search.Benchmarks;

[MemoryDiagnoser]
[WarmupCount(1)]
[IterationCount(5)]
public class SearchBenchmarks
{
    private readonly string[] _testData;
    private readonly SearcherV5 _index;

    [Params("intercontinental", "monday", "not")]
    public string Query { get; set; }

    public SearchBenchmarks()
    {
        _testData = Utils.GetTestData().ToArray();

        _index = new SearcherV5();
        foreach (var item in _testData)
            _index.AddStringToIndex(item);

    }

    //[Benchmark]
    //public void SearcherV2()
    //{
    //    new SearcherV2().Search(Query, _testData);
    //}

    //[Benchmark]
    //public void SearcherV3()
    //{
    //    new SearcherV3().Search(Query, _testData);
    //}

    [Benchmark]
    public void SearcherV4()
    {
        new SearcherV4().Search(Query, _testData).ToList();
    }

    [Benchmark]
    public void SearcherV5()
    {
        new SearcherV5().Search(Query).ToList();//Получаем номера
    }

    [Benchmark]
    public void SearcherV5GetData()
    {
        List<int> result = new SearcherV5().Search(Query).ToList();

        foreach (int index in result)
        {
            string s = _testData[index];
        }
    }

    //[Benchmark]
    //public void SearcherV5AndV4()
    //{
    //    List<int> result = new SearcherV5().Search(Query).ToList();

    //    var searcher = new SearcherV3();//.Search(Query, _testData).ToList();
    //    foreach (int index in result)
    //    {
    //        string s = searcher.Search(Query, _testData[index]);
    //    }


    //}
}
