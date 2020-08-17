﻿using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main()
        {
            Employee ricky =
                new Employee { EmployeeID = 1, Name = "ricky", Rating = 3 };

            Employee mike =
                new Employee { EmployeeID = 2, Name = "mike", Rating = 4 };

            Employee maryann =
                new Employee { EmployeeID = 3, Name = "maryann", Rating = 5 };

            Employee ginger =
                new Employee { EmployeeID = 4, Name = "ginger", Rating = 3 };

            Employee olive =
                new Employee { EmployeeID = 5, Name = "olive", Rating = 4 };

            Employee candy =
                new Employee { EmployeeID = 6, Name = "candy", Rating = 5 };

            Supervisor ronny =
                new Supervisor { EmployeeID = 7, Name = "ronny", Rating = 3 };

            Supervisor bobby =
                new Supervisor { EmployeeID = 8, Name = "bobby", Rating = 3 };

            ronny.AddSubordinate(ricky);
            ronny.AddSubordinate(mike);
            ronny.AddSubordinate(maryann);

            bobby.AddSubordinate(ginger);
            bobby.AddSubordinate(olive);
            bobby.AddSubordinate(candy);

            Console.WriteLine("\n--- Employee can see their Performance " +
                              "Summary --------");
            ricky.PerformanceSummary();

            Console.WriteLine("\n--- Supervisor can also see their " +
                              "subordinates performance summary-----");
            ronny.PerformanceSummary();

            Console.WriteLine("\nSubordinate Performance Record:");
            foreach (Employee employee in ronny.ListSubordinates)
            {
                employee.PerformanceSummary();
            }

            Console.ReadLine();
        }
        // IComponent interface
        public interface IEmployee
        {
            int EmployeeID { get; set; }
            string Name { get; set; }
            int Rating { get; set; }
            void PerformanceSummary();
        }
        //Leaf class 
        public class Employee : IEmployee
        {
            public int EmployeeID { get; set; }
            public string Name { get; set; }
            public int Rating { get; set; }

            public void PerformanceSummary()
            {
                Console.WriteLine("\nPerformance summary of employee: " +
                                  $"{Name} is {Rating} out of 5");
            }
        }
        //Composite class
        public class Supervisor : IEmployee
        {
            public int EmployeeID { get; set; }
            public string Name { get; set; }
            public int Rating { get; set; }

            public List<IEmployee> ListSubordinates = new List<IEmployee>();

            public void PerformanceSummary()
            {
                Console.WriteLine("\nPerformance summary of supervisor: " +
                                  $"{Name} is {Rating} out of 5");
            }

            public void AddSubordinate(IEmployee employee)
            {
                ListSubordinates.Add(employee);
            }
        }
    }
}