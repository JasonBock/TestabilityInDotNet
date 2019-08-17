﻿using Moq;
using NUnit.Framework;
using System;

namespace TestabilityInDotNet.Tests
{
	public static class ServiceUserTests
	{
		[Test]
		public static void CreateWithNull() =>
			Assert.That(() => new ServiceUser(null), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void Use()
		{
			// Arrange
			var id = Guid.NewGuid();
			var serviceMock = new Mock<IService>(MockBehavior.Strict);
			serviceMock.Setup(_ => _.GetId()).Returns(id);

			// Act
			var serviceUser = new ServiceUser(serviceMock.Object);

			// Assert
			Assert.That(serviceUser.Use(), Is.EqualTo(id));
			serviceMock.VerifyAll();
		}
	}
}