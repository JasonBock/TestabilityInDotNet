using NUnit.Framework;
using Rocks;
using System;

namespace TestabilityInDotNet.Tests
{
	public static class PersonServiceConsumerWithRocksTests
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

			var personServiceMock = Rock.Create<IPersonService>();
			personServiceMock.Methods().Get(id).Returns(person);

			// Act
			var serviceUser = new PersonServiceConsumer(personServiceMock.Instance());

			// Assert
			Assert.That(serviceUser.Find(id), Is.EqualTo(person));
			personServiceMock.Verify();
		}
	}
}