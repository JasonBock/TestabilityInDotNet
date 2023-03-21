using Moq;
using NUnit.Framework;
using System;

namespace TestabilityInDotNet.Tests
{
	public static class ServiceUserWithMoqTests
	{
		[Test]
		public static void CreateWithNull() =>
			Assert.That(() => new ServiceUser(null!), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void Use()
		{
			// Arrange
			var id = Guid.NewGuid();
			var repository = new MockRepository(MockBehavior.Strict);
			var serviceMock = repository.Create<IService>();
			serviceMock.Setup(_ => _.GetId()).Returns(id);

			// Act
			var serviceUser = new ServiceUser(serviceMock.Object);

			// Assert
			Assert.That(serviceUser.Use(), Is.EqualTo(id));
			repository.VerifyAll();
		}
	}
}