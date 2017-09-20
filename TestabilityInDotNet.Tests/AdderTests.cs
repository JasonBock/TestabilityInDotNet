using NUnit.Framework;

namespace TestabilityInDotNet.Tests
{
	[TestFixture]
	public sealed class AdderTests
	{
		[Test]
		public void Add() => Assert.That(Adder.Add(3, 6), Is.EqualTo(9));

		[Test]
		public void AddWithOverflow() => Assert.That(Adder.Add(int.MaxValue, int.MaxValue), Is.EqualTo(-2));
	}
}
