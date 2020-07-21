using NUnit.Framework;
using System.Threading.Tasks;

namespace TestabilityInDotNet.Tests
{
	public static class ParallelOneTests
	{
		[TestCase(1700)]
		[TestCase(1800)]
		[TestCase(1900)]
		[TestCase(2000)]
		public static void RunDelay(int millisecondDelayValue) =>
			Assert.DoesNotThrowAsync(async () => await Task.Delay(millisecondDelayValue));
	}

	public static class ParallelTwoTests
	{
		[TestCase(1700)]
		[TestCase(1800)]
		[TestCase(1900)]
		[TestCase(2000)]
		public static void RunDelay(int millisecondDelayValue) =>
			Assert.DoesNotThrowAsync(async () => await Task.Delay(millisecondDelayValue));
	}
}