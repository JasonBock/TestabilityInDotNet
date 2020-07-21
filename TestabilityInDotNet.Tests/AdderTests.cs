using NUnit.Framework;

namespace TestabilityInDotNet.Tests
{
	public static class AdderTests
	{
		[Test]
		public static void Add()
		{
			// Arrange
			var x = 3;
			var y = 6;

			// Act
			var result = Adder.Add(x, y);

			// Assert
			Assert.That(result, Is.EqualTo(9));
		}

		//[Test]
		//public static void AddWithOverflow() => Assert.That(
		//	Adder.Add(int.MaxValue, int.MaxValue), Is.EqualTo(-2));

		//Use TestCaseSource for data that is generated at runtime
		[TestCase(2, 2, ExpectedResult = 4)]
		[TestCase(int.MaxValue, int.MaxValue, ExpectedResult = -2)]
		public static int ParameterizedAdd(int x, int y) => Adder.Add(x, y);

		//[Test]
		//public static void Add() => Assert.That(Adder.Add(3, 6), Is.EqualTo(9));

		//[Test]
		//public static void AddWithOverflow() =>
		//	Assert.That(() => Adder.Add(int.MaxValue, int.MaxValue),
		//		Throws.TypeOf<OverflowException>());
	}
}