using Microsoft.EntityFrameworkCore;
using OutboxPatternWithCdc.Data.Outbox;

namespace OutboxPatternWithCdc.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOutbox> ProductOutboxes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryOutbox> CategoryOutboxes { get; set; }
    
}