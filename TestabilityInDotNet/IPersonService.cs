using System;

namespace TestabilityInDotNet
{
	public interface IPersonService
	{
		Person Get(Guid id);
	}
}