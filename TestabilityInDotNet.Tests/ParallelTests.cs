using NUnit.Framework;
using System.Threading.Tasks;

namespace TestabilityInDotNet.Tests;

public static class ParallelOneTests
{
	[TestCase(1997)]
	[TestCase(1998)]
	[TestCase(1999)]
	[TestCase(2000)]
	public static void RunDelay(int millisecondDelayValue) =>
		Assert.DoesNotThrowAsync(async () => await Task.Delay(millisecondDelayValue).ConfigureAwait(false));
}

public static class ParallelTwoTests
{
	[TestCase(1997)]
	[TestCase(1998)]
	[TestCase(1999)]
	[TestCase(2000)]
	public static void RunDelay(int millisecondDelayValue) =>
		Assert.DoesNotThrowAsync(async () => await Task.Delay(millisecondDelayValue).ConfigureAwait(false));
}