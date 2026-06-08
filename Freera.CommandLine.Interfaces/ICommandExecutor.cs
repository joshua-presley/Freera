namespace Freera.CommandLine.Interfaces
{
    public interface ICommandExecutor
    {
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
        void Execute(string[] args);
    }
}
