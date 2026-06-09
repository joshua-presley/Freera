
using Freera.CommandLine;


class Program()
{
    static void Main(string[] args)
    {
        var commandExecutor = new CommandExecutor();
        commandExecutor.Execute(args);
    }
}