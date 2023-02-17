``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]   : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|        Method |      Job |  Runtime |     Mean |    Error |   StdDev | Allocated |
|-------------- |--------- |--------- |---------:|---------:|---------:|----------:|
|     For_Array | .NET 5.0 | .NET 5.0 |       NA |       NA |       NA |         - |
| ForEach_Array | .NET 5.0 | .NET 5.0 |       NA |       NA |       NA |         - |
|      For_List | .NET 5.0 | .NET 5.0 |       NA |       NA |       NA |         - |
|  ForEach_List | .NET 5.0 | .NET 5.0 |       NA |       NA |       NA |         - |
|     For_Array | .NET 6.0 | .NET 6.0 | 236.8 ns |  4.66 ns |  5.54 ns |         - |
| ForEach_Array | .NET 6.0 | .NET 6.0 | 223.9 ns |  1.71 ns |  1.60 ns |         - |
|      For_List | .NET 6.0 | .NET 6.0 | 348.8 ns |  6.97 ns | 10.00 ns |         - |
|  ForEach_List | .NET 6.0 | .NET 6.0 | 578.9 ns | 11.53 ns | 19.27 ns |         - |

Benchmarks with issues:
  BenchMarks.For_Array: .NET 5.0(Runtime=.NET 5.0)
  BenchMarks.ForEach_Array: .NET 5.0(Runtime=.NET 5.0)
  BenchMarks.For_List: .NET 5.0(Runtime=.NET 5.0)
  BenchMarks.ForEach_List: .NET 5.0(Runtime=.NET 5.0)
