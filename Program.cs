using Docker.DotNet;
using Docker.DotNet.Models;
using System.CommandLine;


var client = new DockerClientConfiguration().CreateClient();

var dockerImageNameOption = new Option<string>(
        name: "--image-name",
        description: "Image name to search"
    );

var dockerImageLimitOption = new Option<long?>(
        name: "--count",
        description: "Limit. Default null"
    );

var rootCommand = new RootCommand("Sample Docker CLI");
rootCommand.AddOption(dockerImageNameOption);
rootCommand.AddOption(dockerImageLimitOption);

var c = new Command("create-container");
var createContainerNameOption = new Option<string>(
        name: "--container-name",
        description: "Container name"
    );
c.AddOption(createContainerNameOption);
c.SetHandler((containerName) =>
{
    Console.WriteLine($"{containerName}");
}, createContainerNameOption);

rootCommand.AddCommand(c);

rootCommand.SetHandler(async (imageName, imageCount) =>
{
    var images = await client.Images.SearchImagesAsync(new Docker.DotNet.Models.ImagesSearchParameters()
    {
        Term = imageName,
        Limit = imageCount
    });

    foreach (var image in images)
    {
        Console.WriteLine("----------------");
        Console.WriteLine($"Image: {image.Name}");
        Console.WriteLine($"Description: {image.Description}");
        Console.WriteLine($"Start: {image.StarCount}");
        Console.WriteLine($"Official: {(image.IsOfficial ? "Yes" : "No")}");
        Console.WriteLine("----------------");
        Console.WriteLine(Environment.NewLine);
    }

}, dockerImageNameOption, dockerImageLimitOption);

await rootCommand.InvokeAsync(args);

//var containers = await client.Containers.ListContainersAsync(new Docker.DotNet.Models.ContainersListParameters()
//{
//    Limit = 10,
//});

//var images = await client.Images.SearchImagesAsync(new Docker.DotNet.Models.ImagesSearchParameters()
//{
//    Limit = 3,
//    Term = "redis"
//});

//foreach (var image in images)
//{
//    Console.WriteLine("----------------");
//    Console.WriteLine($"Image: {image.Name}");
//    Console.WriteLine($"Description: {image.Description}");
//    Console.WriteLine($"Start: {image.StarCount}");
//    Console.WriteLine($"Official: {(image.IsOfficial ? "Yes" : "No")}");
//    Console.WriteLine("----------------");
//    Console.WriteLine(Environment.NewLine);
//}

//var progress = new Progress<JSONMessage>(message =>
//{
//    Console.WriteLine($"{message.Status} {message.ProgressMessage}");
//});

//await client.Images.CreateImageAsync(new Docker.DotNet.Models.ImagesCreateParameters()
//{
//    FromImage = "redis",
//    Tag = "latest"
//}, null, progress);