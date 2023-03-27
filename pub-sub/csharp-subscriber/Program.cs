using Dapr;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Dapr configurations
app.UseCloudEvents();

app.MapSubscribeHandler();


static string toString(List<byte> input)
{
    string result = string.Empty;
    for (int i = 0; i < input.Count(); i++)
    {
        result += Convert.ToChar(input[i]);
    }
    return result;
}

static List<byte> toBytes(string input)
{
    List<byte> result = new List<byte>();
    for (int i = 0; i < input.Length; i++)
    {
        result.Add(Convert.ToByte(input[i]));
    }
    return result;
}


app.MapPost("/A", [Topic("pubsub", "A")] (ILogger<Program> logger, MessageEvent item) =>
{
    var result = LZSS.Compress(toBytes(item.Message));
    var textResult = toString(result);
    Console.WriteLine($"{item.MessageType}: {item.Message} =====> LZSS Compression: {textResult}");
    return Results.Ok(textResult);
});

app.MapPost("/B", [Topic("pubsub", "B")] (ILogger<Program> logger, MessageEvent item) =>
{
    var result = LZSS.Decompress(toBytes(item.Message));
    var textResult = toString(result);
    Console.WriteLine($"{item.MessageType}: {item.Message} =====> LZSS Decompression: {textResult}");
    return Results.Ok(textResult);
});

app.MapPost("/C", [Topic("pubsub", "C")] (ILogger<Program> logger, Dictionary<string, string> item) =>
{
    Console.WriteLine($"{item["messageType"]}: {item["message"]}");
    return Results.Ok();
});

app.Run();

internal record MessageEvent(string MessageType, string Message);