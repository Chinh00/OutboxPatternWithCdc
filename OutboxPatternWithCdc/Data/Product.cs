using OutboxPatternWithCdc.Cores;

namespace OutboxPatternWithCdc.Data;

public class Product : EntityBase
{
    public string Name { get; set; }
}