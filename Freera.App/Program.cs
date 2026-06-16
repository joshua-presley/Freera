
using Freera.CommandLine;
using Freera.CommandLine.Interfaces;
using Freera.Interfaces;


using Freera.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program()
{
    static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ICommandExecutor, CommandExecutor>();
        //builder.Services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
        //builder.Services.AddTransient<ServiceLifetimeReporter>();

       using IHost host = builder.Build();

       var commandExecutor = host.Services.GetRequiredService<ICommandExecutor>();
       commandExecutor.Execute(args);
    }
}
