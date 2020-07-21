using BenchmarkDotNet.Running;

namespace TestabilityInDotNet.Performance
{
	class Program
	{
		static void Main() => BenchmarkRunner.Run<CreatingRandomBigIntegers>();
	}
}