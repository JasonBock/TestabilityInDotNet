using NUnit.Framework;
using System;

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
		//public static void Add() => Assert.That(Adder.Add(3, 6), Is.EqualTo(9));

		[Test]
		public static void AddWithOverflow() => Assert.That(
			Adder.Add(int.MaxValue, int.MaxValue), Is.EqualTo(-2));

		//[Test]
		//public static void AddWithOverflow() =>
		//	Assert.That(() => Adder.Add(int.MaxValue, int.MaxValue), 
		//		Throws.TypeOf<OverflowException>());
	}
}