using System;
using System.Collections.Generic;
using System.Text;

namespace Freera.Exceptions
{
    /// <summary>
    /// Exception for when no input is provided to the program.
    /// </summary>
    public class EmptyCommandException(): Exception("No command was provided")
    {
    }
}
