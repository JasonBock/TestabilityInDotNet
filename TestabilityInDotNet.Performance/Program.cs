using BenchmarkDotNet.Running;
using BenchmarkTreeGeneration;

namespace TestabilityInDotNet.Performance
{
	class Program
	{
		static void Main() => BenchmarkRunner.Run<CreatingRandomBigIntegers>();
	}
}