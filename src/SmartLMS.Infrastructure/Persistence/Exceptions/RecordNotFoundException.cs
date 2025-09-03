namespace SmartLMS.Infrastructure.Persistence.Exceptions;

public class RecordNotFoundException : Exception
{
	public RecordNotFoundException(string entityName, Guid id)
		: base($"{entityName} with ID {id} was not found.") { }
}
