using Microsoft.EntityFrameworkCore;
using CRUD_order;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderDb>(opt => opt.UseInMemoryDatabase("crudOrder"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/crud", async (OrderDb db) =>
    await db.Orders.ToListAsync());



app.MapGet("/crud/{id}", async (int id, OrderDb db) =>
    await db.Orders.FindAsync(id)


        is Order orDer
        ? Results.Ok(orDer) : Results.NotFound());

app.MapPost("/crud", async (Order order, OrderDb db) =>
{
    db.Orders.Add(order);
    await db.SaveChangesAsync();

    return Results.Created($"/crud/{order.OrderId}", order);
});

app.MapPut("/crud/{id}", async (int id, Order inputOrder, OrderDb db) =>
{
    var order = await db.Orders.FindAsync(id)

;
    if (order == null) return Results.NotFound();

    order.TotalAmount = inputOrder.TotalAmount;
    order.Status = inputOrder.Status;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/crud/{id}", async (int id, OrderDb db) =>
{
    if (await db.Orders.FindAsync(id)

 is Order order)
    {
        db.Orders.Remove(order);
        await db.SaveChangesAsync();
        return Results.Ok(order);
    }
    return Results.NotFound();
});
app.Run();