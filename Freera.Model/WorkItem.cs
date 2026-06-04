using Freera.Exceptions;
using Freera.Interfaces;

namespace Freera.Model
{
    public class WorkItem : IObjectWithId
    {
        public Guid Id => _id;

        /// <summary>
        ///Title of the work item. User supplied. 
        /// </summary>
        string Title => _title;

        /// <summary>
        /// Description body. Basic user supplied text
        /// value. 
        /// </summary>
        /// <remarks>
        /// Probably want to extend styling to this at some point.
        /// </remarks>
        string Description => _description;

        /// <summary>
        /// User supplied priority. Optional.
        /// </summary>
        int? Priority => _priority;

        /// <summary>
        /// Reference to parent object.
        /// </summary>
        WorkItem Parent => _parent;

        /// <summary>
        /// List of child items belonging to this Work Item.
        /// There is no limit on the size of the tree. That is,
        /// these children may also be parents of other work items.
        /// </summary>
        List<WorkItem> Children;

        /// <summary>
        /// State of this Work Item. This is a custom, user defined value.
        /// </summary>
        WorkItemState State => _state;

        public void SetParent(WorkItem workItem)
        {
            if (this._parent != null)
            {
                throw new ParameterValidationException("When setting Parent in WorkItem, Parent was already set.", nameof(workItem));
            }
            this._parent = workItem;
        }

        public void AddChild(WorkItem child)
        {
            if(child.Id == this.Id)
            {
                
            }
            this._children.ForEach(existingChild =>
            {
                if (existingChild.Id == child.Id)
                {
                    throw new DuplicateChildException(this.Id, child.Id);
                }
            });
        }


        public WorkItem(string title, string description, int? priority)
        {
            this._id = Guid.NewGuid();
            this._title = title;
            this._description = description;
            this._priority = priority;
        }


        private Guid _id;
        private string _title;
        private string _description;
        private int? _priority;
        private WorkItem _parent;
        private List<WorkItem> _children;
        private WorkItemState _state;
    }
}
