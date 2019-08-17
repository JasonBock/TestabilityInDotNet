using System;

namespace TestabilityInDotNet
{
	public sealed class ServiceUser
	{
		private readonly IService service;

		public ServiceUser(IService service) =>
			this.service = service ?? throw new ArgumentNullException(nameof(service));

		public Guid Use() => this.service.GetId(); // Guid.NewGuid();
	}
}