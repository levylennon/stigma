namespace Stigma.Servers.GameServer;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        
        var app = builder.Build();

        app.Run();
    }
}