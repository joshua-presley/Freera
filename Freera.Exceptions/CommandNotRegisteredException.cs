using System;
using System.Collections.Generic;
using System.Text;

namespace Freera.Exceptions
{
    public class CommandNotRegisteredException(string methodName): Exception($"Could not find a registered command named {methodName}. Did you forget to register it?")
    {
    }
}
