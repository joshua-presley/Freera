
namespace Freera.Model
{

    /// <summary>
    /// Allows users to define custom states. Basically a custom enum structure.
    /// </summary>
    public class WorkItemState
    {
        public Guid Id => _id;
        /**
         *
         */
        public int Value => _value;
        public string Label => _label;

        public WorkItemState(Guid id, int value, string label)
        {
            _id = id;
            _value = value;
            _label = label;
        }

        private Guid _id;
        private int _value;
        private string _label;
    }
}
