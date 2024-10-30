using System.Text.Json;
using Newtonsoft.Json;
using OutboxPatternWithCdc.Data;
using OutboxPatternWithCdc.Data.Outbox;

namespace OutboxPatternWithCdc.Apis;

public static class OutboxApi
{
    public static IEndpointRouteBuilder AddOutboxApi(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("api/outbox");

        group.MapPost(string.Empty, async (string name, DataContext context) =>
            {
               
                await using var transaction = await context.Database.BeginTransactionAsync();
                var product = await context.Set<Product>().AddAsync(new Product { Name = name });
                await context.Set<ProductOutbox>().AddAsync(new ProductOutbox()
                {
                    AggregateType = nameof(product),
                    AggregateId = product.Entity.Id,
                    EventType = "ProductCreated",
                    Payload = JsonConvert.SerializeObject(JsonConvert.SerializeObject(product.Entity))
                });

                var category = await context.Set<Category>().AddAsync(new Category()
                {
                        
                });
                await context.Set<CategoryOutbox>().AddAsync(new CategoryOutbox()
                {
                    AggregateType = nameof(category),
                    AggregateId = product.Entity.Id,
                    EventType = "CategoryCreated",
                    Payload = JsonConvert.SerializeObject(JsonConvert.SerializeObject(category.Entity))
                });
                
                
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
                
                return TypedResults.Ok(product.Entity.Id);
            })
            .WithName("GetOutbox")
            .WithTags("Outbox");

        return routeBuilder;
    }
}