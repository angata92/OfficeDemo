using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t1 = new Task("Task 1", 16); 
            //Task t2 = new Task("Task 2", 5);
            //Task t3 = new Task("Task 3", 7);
            //Task t4 = new Task("Task 4", 2);
            //Task t5 = new Task("Task 5", 32);
            //Task t6 = new Task("Task 6", 49);
            //Task t7 = new Task("Task 7", 18); 
            //Task t8 = new Task("Task 8", 2);
            //Task t9 = new Task("Task 9", 3);
            //Task t10 = new Task("Task 10", 2);

            //Task t1 = new Task("Task 1", 49);
            //Task t2 = new Task("Task 2", 32);
            //Task t3 = new Task("Task 3", 18);
            //Task t4 = new Task("Task 4", 16);
            //Task t5 = new Task("Task 5", 7);
            //Task t6 = new Task("Task 6", 5);
            //Task t7 = new Task("Task 7", 3);
            //Task t8 = new Task("Task 8", 2);
            //Task t9 = new Task("Task 9", 2);
            //Task t10 = new Task("Task 10", 1);


            // How to initialize persons sample

            Person person1 = new Person("Ivan", "Ivanov");
            person1.SecondName = "Draganov";
            person1.Height = 175;

            person1.SexType = Sex.Male;
            
            person1.PhoneNumbers = new PhoneNumber[2];
            person1.PhoneNumbers[0] = new PhoneNumber("0888 45 56 67", TypePhoneNumber.HomeNumber);
            person1.PhoneNumbers[1] = new PhoneNumber("0888 45 56 78", TypePhoneNumber.MobileNumber);

            person1.PersonalNumber = "34565465656";

            person1.Addresses = new Address[3];
            person1.Addresses[0] = new Address();
            person1.Addresses[0].Country = "Bulgaria";
            person1.Addresses[0].City = "Pld";
            person1.Addresses[0].AddressType = TypeAddress.HomeAddress;
            person1.Addresses[0].AddressLine1 = "Center Hali House N45";

            Address address2 = new Address()
            {
                Country = "Bulgaria",
                City = "Sf",
                AddressType = TypeAddress.WorkAddress,
                AddressLine1 = "Center NDK House N47"
            };

            person1.Addresses[1] = address2;

            Address address3 = new Address();
            
            
            address3.Country = "Bulgaria";
            address3.City = "Varna";
            address3.AddressType = TypeAddress.HomeAddress;
            address3.AddressLine1 = "Center Garden House N49";


            person1.Addresses[2] = address3;

            // End of How to initialize persons sample


            Task t1 = new Task("Task 1", 1);
            Task t2 = new Task("Task 2", 2);
            Task t3 = new Task("Task 3", 2);
            Task t4 = new Task("Task 4", 3);
            Task t5 = new Task("Task 5", 5);
            Task t6 = new Task("Task 6", 7);
            Task t7 = new Task("Task 7", 16);
            Task t8 = new Task("Task 8", 18);
            Task t9 = new Task("Task 9", 32);
            Task t10 = new Task("Task 10", 49);

            Employee[] employees = new Employee[]
                                   {
                                       new Employee(new Person("Ivan", "Ivanov")), 
                                       new Employee(new Person("Nikola", "Nikolov")), 
                                       new Employee(new Person("Petya", "Petrova"))
                                   };

            AllWork work = new AllWork();
            work.AddTask(t1);
            work.AddTask(t2);
            work.AddTask(t3);
            work.AddTask(t4);
            work.AddTask(t5);
            work.AddTask(t6);
            work.AddTask(t7);
            work.AddTask(t8);
            work.AddTask(t9);
            work.AddTask(t10);

            Employee.AllWork = work;

            int day = 1;
            while (true)
            {
                Console.WriteLine();

                Console.WriteLine("_______________ day " + day + "_______________");

                if (!Employee.AllWork.IsAllWorkDone)
                {
                    for (int i = 0; i < employees.Length; i++)
                    {
                        employees[i].StartWorkingDay();
                        employees[i].Work();
                    }
                }

                if (Employee.AllWork.IsAllWorkDone)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("The work is done :)");
                    break;
                }

                day++;
            }

            Console.ReadKey();

        }
    }
}
