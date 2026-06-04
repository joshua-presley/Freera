using System;
using System.Collections.Generic;
using System.Text;

namespace Freera.Exceptions
{
    public class ParameterValidationException(string message, string parameterName) : Exception(message + $"\nParameter name: {parameterName}")
    {
    }
}
