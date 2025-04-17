using System.Text.Json;

var client = new HttpClient();

var response = await client.GetAsync("https://swapi.tech/api/people/1/");
var content = await response.Content.ReadAsStringAsync();
var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var deserializedResponse = JsonSerializer.Deserialize<SwapiPersonResponse>(content, options);

var person = deserializedResponse?.Result?.Properties;
if (person != null)
    Console.WriteLine($"Name: {person.Name}, Height: {person.Height}, Gender: {person.Gender}");
else
    Console.WriteLine("Person not found");

public class SwapiPersonProperties
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string Gender { get; set; }
}

public class SwapiPersonResult
{
    public SwapiPersonProperties Properties { get; set; }
}

public class SwapiPersonResponse
{
    public string  Message { get; set; }
    public SwapiPersonResult Result { get; set; }
}