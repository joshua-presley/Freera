
namespace Freera.Exceptions
{
    /// <summary>
    /// Thrown when trying to add something as a child of itself.
    /// </summary>
    public class SelfReferenceException(): Exception("A work item cannot reference itself.")
    {
    }
}
