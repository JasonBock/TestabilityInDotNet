namespace TestabilityInDotNet
{
	public static class Adder
	{
		public static int Add(int x, int y) => x + y;

		//public static int Add(int x, int y)
		//{
		//	checked { return x + y; }
		//}
	}
}
