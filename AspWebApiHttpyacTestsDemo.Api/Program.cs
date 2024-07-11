var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

List<Person> people = [];

app.MapGet("/people", () =>
{
    return Results.Ok(people);
});
app.MapGet("/people/{id:int}", (int id) =>
{
    Person? person = people.FirstOrDefault(x => x.Id == id);
    if (person is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(person);
});
app.MapPost("/people", (Person person) =>
{
    Person created = person with { Id = people.Count + 1 };
    people.Add(created);
    return Results.Created($"/people/{created.Id}", person);
});
app.MapPut("/people/{id:int}", (int id, Person person) =>
{
    Person? existing = people.FirstOrDefault(x => x.Id == id);
    if (existing is null)
    {
        return Results.NotFound();
    }
    people.Remove(existing);
    people.Add(person);
    return Results.NoContent();
});
app.MapDelete("/people/{id:int}", (int id) =>
{
    Person? existing = people.FirstOrDefault(x => x.Id == id);
    if (existing is null)
    {
        return Results.NotFound();
    }
    people.Remove(existing);
    return Results.NoContent();
});

app.Run();

internal record Person(int Id, string FirstName, string LastName, int Age, string Email);
