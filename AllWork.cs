using System;

namespace OfficeDemo
{
    public class AllWork
    {
        public const int TaskSlotsCount = 10;

        private Task[] _tasks;

        private int _freePlacesForTasks;

        private int _currentUnassignedTaskIndex;

        public bool IsAllWorkDone
        {
            get
            {
                for (int i = 0; i < this._tasks.Length - this._freePlacesForTasks; i++)
                {
                    if (this._tasks[i].WorkingHours > 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public AllWork()
        {
            this._tasks = new Task[TaskSlotsCount];

            this._freePlacesForTasks = TaskSlotsCount;

            this._currentUnassignedTaskIndex = 0;
        }

        public void AddTask(Task task)
        {
            if (task == null)
            {
                return;
            }

            if (this._freePlacesForTasks > 0)
            {
                this._tasks[this._tasks.Length - this._freePlacesForTasks] = task;

                //this._tasks[this._currentUnassignedTaskIndex] = task;

                //this._currentUnassignedTaskIndex++;

                this. _freePlacesForTasks--;

                Console.WriteLine(task.Name + " has been added.");
            }
            else
            {
                Console.WriteLine("No free places for tasks!");
            }
        }

        public Task GetNextTask()
        {
            if (this._currentUnassignedTaskIndex >= this._tasks.Length || this._tasks[this._currentUnassignedTaskIndex] == null)
            {
                return null;
            }
                      
            Task nextTask = this._tasks[this._currentUnassignedTaskIndex];

            this._currentUnassignedTaskIndex++;

            return nextTask;
        }        
    }
}
