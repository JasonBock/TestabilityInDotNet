using NUnit.Framework;
using Rocks;
using System;

namespace TestabilityInDotNet.Tests;

public static class PersonServiceConsumerWithRocksTests
{
	[Test]
	public static void CreateWithNull() =>
		Assert.That(() => new PersonServiceConsumer(null!), Throws.TypeOf<ArgumentNullException>());

	[RockCreate<IPersonService>]
	[Test]
	public static void Find()
	{
		// Arrange
		var id = Guid.NewGuid();
		var person = new Person(id, "Joe Smith", 30);

		var personServiceMock = new IPersonServiceCreateExpectations();
		personServiceMock.Methods.Get(id).ReturnValue(person);

		// Act
		var serviceUser = new PersonServiceConsumer(personServiceMock.Instance());

		// Assert
		Assert.That(serviceUser.Find(id), Is.EqualTo(person));
		personServiceMock.Verify();
	}
}