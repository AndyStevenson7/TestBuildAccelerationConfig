using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        IConfiguration config = builder.Build();

        Console.WriteLine(config.GetValue<string>("config1"));
        Console.WriteLine(config.GetValue<string>("config2"));
    }
}