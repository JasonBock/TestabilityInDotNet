using System;

namespace TestabilityInDotNet
{
	public interface IPersonService
	{
		// If the id is not Guid.Empty, return a user.
		// Else, throw an exception.
		Person Get(Guid id);
	}
}