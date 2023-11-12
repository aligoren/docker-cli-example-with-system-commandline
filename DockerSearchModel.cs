public class DockerSearchModel
{
    public string ImageName { get; set; }

    public long? Limit { get; set; }
}

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