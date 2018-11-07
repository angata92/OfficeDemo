using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeDemo
{
    public class Employee
    {
        public const int DayWorkHours = 8;

        public static AllWork AllWork { get; set; }

        public Person EmployeePerson { get; set; }

        private int _hoursLeft;

        public int HoursLeft
        {
            get { return this._hoursLeft; }
            set
            {
                if (value >= 0)
                {
                    this._hoursLeft = value;
                }
            }
        }

        private Task _currentTask;

        public Task CurrentTask
        {
            get { return this._currentTask; }
            set
            {
                if (value != null && value.WorkingHours > 0)
                {
                    this._currentTask = value;
                }
                else
                {
                    Console.WriteLine("Not valid task!!!");
                }
            }
        }

        public Employee(Person person)
        {
            this.EmployeePerson = person;

            this._hoursLeft = DayWorkHours;
        }

        public void Work()
        {
            while (this._hoursLeft > 0)
            {
                if (this._currentTask == null || this._currentTask.WorkingHours == 0)
                {
                    this._currentTask = AllWork.GetNextTask();
                    
                    if (this._currentTask == null)
                    {
                        Console.WriteLine("No free task for " + this.EmployeePerson.FullName);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Assigning {0} to {1}", this._currentTask.Name, this.EmployeePerson.FullName);
                    }
                }

                if (this._hoursLeft > this._currentTask.WorkingHours)
                {
                    this._hoursLeft -= this._currentTask.WorkingHours;
                    this._currentTask.WorkingHours = 0;
                }
                else
                {
                    this._currentTask.WorkingHours -= this._hoursLeft;
                    this._hoursLeft = 0;
                }

                this.ShowReport();
            }
        }

        public void ShowReport()
        {
            Console.WriteLine("Employee name: " + this.EmployeePerson.FullName);
            Console.WriteLine("Employee hours left: " + this._hoursLeft);

            if (this._currentTask != null)
            {
                Console.WriteLine("Task hours left: " + this._currentTask.WorkingHours);
                Console.WriteLine("Task: " + this._currentTask.Name);
            }
            else
            {
                Console.WriteLine("No task assigned to this employee!");
            }
        }

        public void StartWorkingDay()
        {
            this._hoursLeft = DayWorkHours;
            Console.WriteLine(this.EmployeePerson.FullName + " start working day");
        }

    }
}
