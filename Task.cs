using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeDemo
{
    public class Task
    {
        private string _name;

        public string Name
        {
            get { return this._name; }
            set
            {
                if (value != null)
                {
                    this._name = value;
                }
                else
                {
                    this._name = "";
                }
            }
        }

        private int _workingHours;

        public int WorkingHours
        {
            get { return this._workingHours; }
            set
            {
                if (value >= 0)
                {
                    this._workingHours = value;
                }
            }
        }

        public Task(string name, int workingHours)
        {
            this.Name = name;
            this.WorkingHours = workingHours;
        }
    }
}
