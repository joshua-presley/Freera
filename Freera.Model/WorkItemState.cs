
namespace Freera.Model
{

    /// <summary>
    /// Allows users to define custom states. Basically a custom enum structure.
    /// </summary>
    public class WorkItemState
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string Label { get; set; }

    }
}
