using NUnit.Framework;

namespace TestabilityInDotNet.Tests;

public static class FizzBuzzClassifierTests
{
	[Test]
	public static void ClassifyFizz() => Assert.That(FizzBuzzClassifier.Classify(3), Is.EqualTo(Classifier.Fizz));

	[Test]
	public static void ClassifyBuzz() => Assert.That(FizzBuzzClassifier.Classify(5), Is.EqualTo(Classifier.Buzz));

	[Test]
	public static void ClassifyFizzBuzz() => Assert.That(FizzBuzzClassifier.Classify(15), Is.EqualTo(Classifier.FizzBuzz));

	//[Test]
	//public static void ClassifyNone() => Assert.That(FizzBuzzClassifier.Classify(2), Is.Null);

	//[Test]
	//public static void ClassifyNoneWithNoAssertion() => FizzBuzzClassifier.Classify(2);
}