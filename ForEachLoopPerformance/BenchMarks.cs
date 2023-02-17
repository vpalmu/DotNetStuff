using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LoopsAreFixed
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [MemoryDiagnoser(false)]
    public class BenchMarks
    {
        private int[]? itemsArray;
        private List<int>? itemsList;

        [GlobalSetup]
        public void Setup() 
        {
            var random = new Random(420);
            var randomItems = Enumerable.Range(0, 1000)
                                        .Select(_ => random.Next());

            itemsArray = randomItems.ToArray();
            itemsList = itemsArray.ToList();
        }

        [Benchmark]
        public void For_Array()
        {
            for (int i = 0; i < itemsArray.Length; i++)
            {
                var item = itemsArray[i];
            }
        }

        [Benchmark]
        public void ForEach_Array() 
        {
            foreach (var item in itemsArray) { }
            {

            }
        }

        [Benchmark]
        public void For_List()
        {
            for (int i = 0; i < itemsList.Count; i++)
            {
                var item = itemsList[i];
            }
        }

        [Benchmark]
        public void ForEach_List()
        {
            foreach (var item in itemsList) { }
            {

            }
        }

    }
}
