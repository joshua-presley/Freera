using System;
using System.Collections.Generic;
using System.Text;

namespace Freera.Exceptions
{
    public class ModelNotFoundException(Guid id, Type type): Exception($"Model of type {type} with Id {id} not found.")

    {
    }
}
