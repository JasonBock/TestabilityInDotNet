using System;

namespace TestabilityInDotNet
{
	public sealed class PersonServiceConsumer
	{
		private readonly IPersonService service;

		public PersonServiceConsumer(IPersonService service) =>
			this.service = service ?? throw new ArgumentNullException(nameof(service));

		public Person Find(Guid id) => this.service.Get(id);
	}
}