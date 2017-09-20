using Moq;
using NUnit.Framework;
using System;

namespace TestabilityInDotNet.Tests
{
	[TestFixture]
	public sealed class ServiceUserTests
	{
		[Test]
		public void Use()
		{
			var id = Guid.NewGuid();
			var serviceMock = new Mock<IService>(MockBehavior.Strict);
			serviceMock.Setup(_ => _.GetId()).Returns(id);

			var serviceUser = new ServiceUser(serviceMock.Object);

			Assert.That(serviceUser.Use(), Is.EqualTo(id));

			serviceMock.VerifyAll();
		}
	}
}
