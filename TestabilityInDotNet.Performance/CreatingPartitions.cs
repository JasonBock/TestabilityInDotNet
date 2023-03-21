using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Spackle;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace TestabilityInDotNet.Performance
{
#pragma warning disable CA1822
	[MemoryDiagnoser]
	[Config(typeof(Configuration))]
	public class CreatingPartitions
	{
#pragma warning disable CA1812
		private sealed class Configuration
			: ManualConfig
		{
			public Configuration()
			{
				var baseJob = Job.MediumRun;
				this.AddJob(baseJob.WithNuGet("Spackle", "9.1.0").WithId("9.1.0"));
				this.AddJob(baseJob.WithNuGet("Spackle", "9.1.5").WithId("9.1.5"));
			}
		}
#pragma warning disable CA1812

		public static IEnumerable<(Range<int>, int)> NumberOfDigits()
		{
			yield return (new(0, 100), 4);
			yield return (new(77, 90431), 6);
			yield return (new(6, 9845), 21);
		}

		[Benchmark]
		[ArgumentsSource(nameof(CreatingPartitions.NumberOfDigits))]
		public ImmutableArray<Range<int>> Create((Range<int> range, int numberOfPartitions) values) =>
			values.range.Partition(values.numberOfPartitions);
	}
#pragma warning restore CA1822
}