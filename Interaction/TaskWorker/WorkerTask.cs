using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Interaction.TaskWorker
{
    /// <summary>
    /// A task for the TaskWorker to execute.
    /// </summary>
    public class WorkerTask
    {
        private string _description;
        private Action<WorkerTaskParameters> _task;
        private WorkerTaskParameters _dataObject;

        /// <summary>
        /// Creates a new task definition object for the TaskWorker
        /// </summary>
        /// <param name="description">Human-readable description (help text) for the task.</param>
        /// <param name="task">Callback method to run.</param>
        /// <param name="dataObject">An object containing the parameters of the task</param>
        public WorkerTask(string description, Action<WorkerTaskParameters> task, WorkerTaskParameters dataObject)
        {
            _dataObject = dataObject;
            _task = task;
            _description = description;
        }

        /// <summary>
        /// Synchronously invokes the method represented by the action delegate.
        /// </summary>
        internal void execute()
        {
            _task.DynamicInvoke(_dataObject);
        }
    }
}
