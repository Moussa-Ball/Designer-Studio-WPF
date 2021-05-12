using System.Collections;
using System.Collections.Generic;

namespace Studio.Softer.Workspaces
{
    /// <summary>
    /// Container used to collect all the workspaces used in an application via DLLs.
    /// </summary>
    public class WorkspaceContainer
    {
        /// <summary>
        /// Contains the workspaces used on an application.
        /// </summary>
        public List<Interoperate.Workspaces.Workspace> Workspaces { get; private set; }

        public WorkspaceContainer()
        {
            Workspaces = new List<Interoperate.Workspaces.Workspace>();
        }

        /// <summary>
        /// Add a workspace in the list.
        /// </summary>
        /// <param name="workspace"></param>
        public void AddWorkspace(Interoperate.Workspaces.Workspace workspace)
        {
            Workspaces.Add(workspace);
        }

        /// <summary>
        /// Enumerate this class.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return Workspaces.GetEnumerator();
        }
    }
}
