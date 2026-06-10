using Freera.Exceptions;
using Freera.Interfaces;

namespace Freera.Model
{
    public class WorkItem : IObjectWithId
    {
        public Guid Id { get; set; }

        /// <summary>
        ///Title of the work item. User supplied. 
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Description body. Basic user supplied text
        /// value. 
        /// </summary>
        /// <remarks>
        /// Probably want to extend styling to this at some point.
        /// </remarks>
        string Description { get; set; }

        /// <summary>
        /// User supplied priority. Optional.
        /// </summary>
        int? Priority  {get;set;}

        /// <summary>
        /// Reference to parent object.
        /// </summary>
        WorkItem Parent { get; set; }

        /// <summary>
        /// List of child items belonging to this Work Item.
        /// There is no limit on the size of the tree. That is,
        /// these children may also be parents of other work items.
        /// </summary>
        List<WorkItem> Children = new();

        /// <summary>
        /// State of this Work Item. This is a custom, user defined value.
        /// </summary>
        WorkItemState State { get; set; }

        /// <summary>
        /// Set the parent on this workItem. 
        /// </summary>
        /// <param name="workItem"></param>
        /// <exception cref="ParameterValidationException"></exception>
        public void SetParent(WorkItem workItem)
        {
            if (this.Parent != null)
            {
                throw new ParameterValidationException("When setting Parent in WorkItem, Parent was already set.", nameof(workItem));
            }
            this.Parent = workItem;
        }

        /// <summary>
        /// Link an existing workitem to this WorkItem as a child
        /// </summary>
        /// <param name="child">Existing Work Item to link</param>
        /// <exception cref="SelfReferenceException">If the child and the parent have the same Id</exception>
        /// <exception cref="DuplicateChildException">If the child is already added as a child here.</exception>
        /// <exception cref="NullReferenceException">If the child was null</exception>
        public void AddChild(WorkItem child)
        {
            if(child == null)
            {
                throw new NullReferenceException("Cannot add a null child.");
            }
            if(child.Id == this.Id)
            {
                throw new SelfReferenceException();
            }
            this.Children.ForEach(existingChild =>
            {
                if (existingChild.Id == child.Id)
                {
                    throw new DuplicateChildException(this.Id, child.Id);
                }
            });
            this.Children.Add(child);
            child.SetParent(this);
        }
    }
}
