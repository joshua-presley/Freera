using Freera.CommandLine.Interfaces;
using Freera.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Freera.CommandLine
{

    /// <summary>
    /// Base implementation for classes which execute user commands.
    /// </summary>
    public class CommandExecutor: ICommandExecutor
    {
        public static List<Command> CommandTable { get; set; } = new List<Command>();

        /// <summary>
        /// Run the specified command with the supplied arguements
        /// </summary>
        /// <remarks>
        /// The first arg should always be the command name. Parameter style args are
        /// supplied by passing the param name followed by a value.
        /// Flag style args are passed by adding '-' to the beginning of the parameter name.
        /// </remarks>
        /// <param name="args">User supplied args from the command line. Not sanitized at this point.</param>
        /// <exception cref="EmptyCommandException">If the list of arguments is empty.</exception>
        /// <exception cref="CommandNotRegisteredException">If the command provided could not be found in the system.</exception>
        /// <exception cref="ParameterValidationException">If any parameter is passed without a value where one is required.</exception>
        public void Execute(string[] args)
        {
            if(args.Length == 0 )
            {
                throw new EmptyCommandException();
            }
            var function = args[0];
            var executable = CommandTable.Find(command => command.Name == function);
            if(executable.Equals(null))
            {
                throw new CommandNotRegisteredException(function);
            }


            var parameters = new List<string>();
            var flags = new List<string>();
            for(int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith('-'))
                {
                    flags.Add(args[i]);
                }
                else
                {
                    if (i == args.Length - 1 || args[i + 1].StartsWith("-"))
                    {
                        throw new ParameterValidationException("parameter provided without value.", args[i]);
                    }
                    parameters.Add(args[i] + " " +  args[i + 1]);
                    i++;
                }
            }

            executable.Method(parameters, flags);
        }

        public CommandExecutor()
        {
        }
    }

    /// <summary>
    /// Simple struct which represents a command for the command table.
    /// </summary>
    public struct Command
    {
        public string Name;
        /// <summary>
        /// Any command line method has two parameters: A list of Arguments, and a list of flags.
        /// A flag differs from an argument in that it does not have a value.
        /// </summary>
        public Action<List<string>, List<string>> Method;

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if(obj == null)
            {
                return Name == null || Method == null;
            }
            return base.Equals(obj);
        }

        public static bool operator ==(Command left, Command right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Command left, Command right)
        {
            return !(left == right);
        }

        public override readonly int GetHashCode() => Name.GetHashCode() + Method.GetHashCode();
    }

}
