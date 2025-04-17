// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;

using var client = new HttpClient();
var data = new DummyData { JediName = "obi-wan", LightsaberColor = "blue" };
var json = JsonSerializer.Serialize(data);
var content = new StringContent(json, Encoding.UTF8, "application/json");

var response = await client.PostAsync("https://httpbin.org/post", content);
var result = await response.Content.ReadAsStringAsync();

Console.WriteLine(result);

public class DummyData
{
    public string JediName { get; set; }
    public string LightsaberColor { get; set; }
}