using BoardConnectAPI;

public class Program
{
    /// <summary>
    /// The service provider
    /// </summary>
    public static IServiceProvider Provider { get; private set; }

    /// <summary>
    /// The main method
    /// </summary>
    /// <param name="args">The arguments</param>
    public static void Main(string[] args)
    {
        DI.Host = CreateHostBuilder(args).Build();

        DI.Host.Run();
    }

    /// <summary>
    /// Create the host builder
    /// </summary>
    /// <param name="args">The arguments</param>
    /// <returns></returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}