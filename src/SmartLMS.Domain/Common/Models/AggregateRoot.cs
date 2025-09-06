namespace SmartLMS.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>, IHasDomainEvents
	where TId : notnull
{
	private readonly List<IDomainEvent> _domainEvents = new();

	public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

	protected AggregateRoot() : base() { }

	protected AggregateRoot(TId id) : base(id) { }

	public void AddDomainEvent(IDomainEvent domainEvent)
	{
		_domainEvents.Add(domainEvent);
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}
}
