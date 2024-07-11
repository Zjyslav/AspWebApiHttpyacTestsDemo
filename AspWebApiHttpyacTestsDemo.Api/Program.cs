using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

List<Person> people = [];

app.MapGet("/people", () =>
{
    app.Logger.LogInformation("Executing GET request to /people");
    return Results.Ok(people);
});
app.MapGet("/people/{id:int}", (int id) =>
{
    app.Logger.LogInformation("Executing GET request to /people/{Id}", id);
    Person? person = people.FirstOrDefault(x => x.Id == id);
    if (person is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(person);
});
app.MapPost("/people", (Person person) =>
{
    app.Logger.LogInformation("Executing POST request to /people");
    Person created = person with { Id = people.Count + 1 };
    people.Add(created);
    return Results.Created($"/people/{created.Id}", created);
});
app.MapPut("/people/{id:int}", (int id, Person person) =>
{
    app.Logger.LogInformation("Executing PUT request to /people");
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
    app.Logger.LogInformation("Executing DELETE request to /people/{Id}", id);
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
