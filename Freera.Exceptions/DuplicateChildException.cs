using System;
using System.Collections.Generic;
using System.Text;

namespace Freera.Exceptions
{
    /// <summary>
    /// Thrown when trying to add a child to an item where it has already been added
    /// </summary>
    /// <param name="parentId">Id of the parent item</param>
    /// <param name="childId">Id of the child item that we are trying to add.</param>
    public class DuplicateChildException(Guid parentId, Guid childId) : Exception($"A child with Id {childId} already belongs to parent with Id {parentId}")
    {
    }
}
