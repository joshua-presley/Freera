namespace Freera.CommandLine.Implementation
{
    public class WorkItemCommands
    {
 
        /// <summary>
        /// Create a new work item
        /// </summary>
        /// 
        public void CreateWorkItem(List<string> parameters, List<string> flags)
        {
            
        }

        public WorkItemCommands()
        {
            CommandExecutor.RegisterCommand("CreateWorkItem", CreateWorkItem);
        }

        private readonly 
    }
}
