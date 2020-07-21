namespace TestabilityInDotNet
{
	public static class FizzBuzzClassifier
	{
		public static Classifier? Classify(int value)
		{
			if(value % 3 == 0 && value % 5 == 0)
			{
				return Classifier.FizzBuzz;
			}
			else if (value % 3 == 0)
			{
				return Classifier.Fizz;
			}
			else if(value % 5 == 0)
			{
				return Classifier.Buzz;
			}
			else
			{
				return null;
			}
		}
	}

	public enum Classifier
	{
		Fizz, Buzz, FizzBuzz
	}
}
