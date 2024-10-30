namespace OutboxPatternWithCdc.Cores;

public class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class OutboxBase : EntityBase
{
    public string AggregateType { get; set; }
    public Guid AggregateId { get; set; }
    public string EventType { get; set; }
    public string Payload { get; set; }
}