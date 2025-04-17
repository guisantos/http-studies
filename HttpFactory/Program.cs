// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


// equivalent in a non-console app
//builder.Services.AddHttpClient("SwapiClient", client =>
//{
//    client.BaseAddress = new Uri("https://swapi.tech/api/");
//});

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient("SwapiClient", client =>
        {
            client.BaseAddress = new Uri("https://swapi.tech/api/");
        });

        services.AddTransient<StarWarsService>();
    })
    .Build();

var service = host.Services.GetRequiredService<StarWarsService>();

for (int i = 1; i <= 5; i++)
{
    var person = await service.GetCharacterAsync(i);
    Console.WriteLine($"{i}: {person.Name}");
}