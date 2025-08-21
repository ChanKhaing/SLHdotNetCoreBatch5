using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/snakes", () =>
{
    string folderpath = "Data/Snakes.json";
    var jsonstr = File.ReadAllText(folderpath);
    //var root = JsonConvert.DeserializeObject<Rootobject>(jsonstr);

    var result =    JsonConvert.DeserializeObject<Rootobject>(jsonstr);
    return Results.Ok(result.Tbl_Snake);
}).WithName("GetSnakes")
.WithOpenApi();

app.MapGet("/snake/{id}", (int id) =>
{
    string folderpath = "Data/Snakes.json";
    var jsonstr = File.ReadAllText(folderpath);
    //var root = JsonConvert.DeserializeObject<Rootobject>(jsonstr);

    var result = JsonConvert.DeserializeObject<Rootobject>(jsonstr);
    var item = result.Tbl_Snake.FirstOrDefault(x => x.Id == id);
    return Results.Ok(item);
}).WithName("GetSnake")
.WithOpenApi();

app.Run();



public class Rootobject
{
    public SnakesModel[] Tbl_Snake { get; set; }
}

public class SnakesModel
{
    public int Id { get; set; }
    public string MMName { get; set; }
    public string EngName { get; set; }
    public string Detail { get; set; }
    public string IsPoison { get; set; }
    public string IsDanger { get; set; }
}


