using NUnit.Framework;
using Rocks;
using System;

namespace TestabilityInDotNet.Tests
{
	public static class ServiceUserWithRocksTests
	{
		[Test]
		public static void CreateWithNull() =>
			Assert.That(() => new ServiceUser(null!), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void Use()
		{
			// Arrange
			var id = Guid.NewGuid();
			var serviceMock = Rock.Create<IService>();
			serviceMock.Methods().GetId().Returns(id);

			// Act
			var serviceUser = new ServiceUser(serviceMock.Instance());

			// Assert
			Assert.That(serviceUser.Use(), Is.EqualTo(id));
			serviceMock.Verify();
		}
	}
}