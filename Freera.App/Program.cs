
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Freera.CommandLine.Interfaces;
using Freera.CommandLine;


class Program()
{
    static void Main(string[] args)
    {
        //HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        //builder.Services.AddSingleton<ICommandExecutor, CommandExecutor>();
        //using IHost host = builder.Build();
        //host.Run();
        var commandExecutor = new CommandExecutor();
        commandExecutor.Execute(args);
    }
}