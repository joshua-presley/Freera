using Freera.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Freera.CommandLine
{

    /// <summary>
    /// Base implementation for classes which execute user commands.
    /// </summary>
    public abstract class CommandExecutor
    {
        public static List<Command> CommandTable { get; set; } = [];
        public void Execute(string input)
        {
            var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if(input == "" || tokens.Length == 0 )
            {
                throw new EmptyCommandException();
            }
            var function = tokens[0];
            var executable = CommandTable.Find(command => command.Name == function);
            if(executable.Equals(null))
            {
                throw new CommandNotRegisteredException(function);
            }


            var parameters = new List<string>();
            var flags = new List<string>();
            for(int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].StartsWith('-'))
                {
                    flags.Add(tokens[i]);
                }
                else
                {
                    if (i == tokens.Length - 1 || tokens[i + 1].StartsWith("-"))
                    {
                        throw new ParameterValidationException("parameter provided without value.", tokens[i]);
                    }
                    parameters.Add(tokens[i] + " " +  tokens[i + 1]);
                }
            }


            executable.Method(parameters, flags);
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
