using Moq;
using NUnit.Framework;
using System;

namespace TestabilityInDotNet.Tests;

public static class PersonServiceConsumerWithMoqTests
{
	[Test]
	public static void CreateWithNull() =>
		Assert.That(() => new PersonServiceConsumer(null!), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void Find()
	{
		// Arrange
		var id = Guid.NewGuid();
		var person = new Person(id, "Joe Smith", 30);

		var repository = new MockRepository(MockBehavior.Strict);
		var personServiceMock = repository.Create<IPersonService>();
		personServiceMock.Setup(_ => _.Get(id)).Returns(person);

		// Act
		var consumer = new PersonServiceConsumer(personServiceMock.Object);

		// Assert
		Assert.That(consumer.Find(id), Is.EqualTo(person));
		repository.VerifyAll();
	}
}