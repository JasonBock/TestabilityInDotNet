using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace TestabilityInDotNet.Performance
{
	// See https://github.com/JasonBock/SpackleNet/commit/42529c68f9b69065a62c0cf1c2b6c9b1611e5852#diff-4da1c28e5f7fcdeba3e3ee92e5fb11c6
	[MemoryDiagnoser]
	public class CreatingRandomBigIntegers
	{
		private readonly RandomNumberGenerator random = RandomNumberGenerator.Create();

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int Next(int maxValue)
		{
			var newNumber = new byte[4];
			this.random.GetBytes(newNumber);
			return (int)(BitConverter.ToUInt32(newNumber, 0) % (uint)maxValue);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int Next(int minValue, int maxValue)
		{
			var newNumber = new byte[4];
			this.random.GetBytes(newNumber);

			var range = (uint)maxValue - (uint)minValue;
			return (int)((BitConverter.ToUInt32(newNumber, 0) % range) + minValue);
		}

		public static IEnumerable<ulong> NumberOfDigits()
		{
			yield return 5u;
			yield return 10u;
			yield return 50u;
			yield return 200u;
		}

		[Benchmark]
		[ArgumentsSource(nameof(CreatingRandomBigIntegers.NumberOfDigits))]
		public BigInteger OldWay(ulong numberOfDigits)
		{
			var digit = BigInteger.Zero;

			if (numberOfDigits == 1)
			{
				digit = new BigInteger(this.Next(0, 10));
			}
			else
			{
				var remainingDigits = numberOfDigits;

				while (remainingDigits > 0)
				{
					if (remainingDigits >= 9)
					{
						digit = (1000000000 * digit) + this.Next(100000000, 1000000000);
						remainingDigits -= 9;
					}
					else
					{
						digit = ((int)(Math.Pow(10, remainingDigits)) * digit) +
							this.Next((int)(Math.Pow(10, remainingDigits - 1)), (int)(Math.Pow(10, remainingDigits)));
						remainingDigits = 0;
					}
				}
			}

			return digit;
		}

		[Benchmark(Baseline = true)]
		[ArgumentsSource(nameof(CreatingRandomBigIntegers.NumberOfDigits))]
		public BigInteger NewWay(ulong numberOfDigits)
		{
			if (numberOfDigits < 10)
			{
				var lowerBound = (int)Math.Pow(10, numberOfDigits - 1);
				return new BigInteger(this.Next(lowerBound, lowerBound * 10));
			}
			else
			{
				// This came from solving 2 ^ n = 10 ^ p for n.
				// I'm also adding one more to the size to ensure I generate
				// a number close to the expected size.
				var bits = (int)Math.Ceiling((numberOfDigits + 1) * 3.32192809488736);
				var bufferSize = (int)Math.Ceiling(bits / 8.0);

				var buffer = new byte[bufferSize];
				this.random.GetBytes(buffer);

				// This is to ensure the highest bit is set to one.
				var upperLimit = (byte)(2 ^ (bits % 8));

				if (buffer[bufferSize - 2] < upperLimit)
				{
					buffer[bufferSize - 2] = (byte)(buffer[bufferSize - 2] + upperLimit);
				}

				// Make sure the number will be positive.
				buffer[bufferSize - 1] = 0;
				var number = new BigInteger(buffer);

				// How many numbers did I actually generate?
				var delta = (int)Math.Floor(BigInteger.Log10(number) + 1) - (int)numberOfDigits;

				// Either reduce the size of the number or increase it 
				// (and add in some extra randomness for the low digits)
				// based on the delta.
				if (delta == 0)
				{
					return number;
				}
				else if (delta > 0)
				{
					return number / BigInteger.Pow(new BigInteger(10), delta);
				}
				else
				{
					return number * BigInteger.Pow(new BigInteger(10), -1 * delta) + this.Next(10);
				}
			}
		}
	}
}