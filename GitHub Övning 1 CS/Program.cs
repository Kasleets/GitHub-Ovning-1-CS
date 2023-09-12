namespace GitHub_Övning_1_CS

{
    using System;                                                               //adding libraries
    using System.Collections.Generic;                                           //adding libraries
    using System.IO;                                                            //trying to develop log file, didn't have enough time to finish it

    public class Employee                                                       //class to create individual employees
    {
        public string Name { get; private set; }                                //public name so we can get it, used to store the values
        public decimal Salary { get; private set; }                             //public salary so we can get it, used to store the values
                                                                                //Had to switch to "private set" instead of "set" because the program didn't receive values properly
        public Employee(string name, decimal salary)                            //creating an input that can be used as an 'index' for single employee with its name and salary
        {
            Name = name;                    //case sensitive variable
            Salary = salary;                //case sensitive variable
        }
        public override string ToString()                                       //converting the object to string so it's usable, otherwise it's displaying the program name instead of value, thank you Github...
        {
            return $"Namn: {Name}"+ 
                   $"\nLön: {Salary}\n";
        }
        public class EmployeeRegister                                           //Creating Employee register class with a list 
        {
            private List<Employee> employees = new List<Employee>();            // TODO: creating our first list, need to figure out how to use it with the log file

            public void AddEmployee(string name, decimal salary)                //adding an employee with name and salary, using void so it doesn't return
            {                                                                   // TODO: Figure out how to set different formats in decimal if it is with comma or the dot in different systems and how to implement, better to have decimal points on salary rather than integer
                var employee = new Employee(name, salary);                      //using var to define an employee so c# defines itself
                employees.Add(employee);                                        //adding employee to the list

            }
            public void RegistryDisplay()                                       //method for writing the whole registry that saved data
            {
                Console.WriteLine("\nAnställda lista: ");                     // \n gives us a blank space in between

                foreach (var employee in employees)                             //for the total amount of employess, write out the whole data set
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public class Program                                                    //running a proper program to the user
        {
            // TODO: need to develop log file method and returning values, overwriting old data and making a backup, separate in new class or write 2 methods
            /*trying to create a method for saving a log file with employees so it can backup the input data
            public static void SaveToLog(EmployeeRegister register)
            {

            } */
            static void Main(string[] args)                                     //regular main program
            {
                EmployeeRegister employeeRegister = new EmployeeRegister();     //Defining employee registry
                                                                                // TODO: add a breakpoint to avoid memory leak in this place
                while (true)                                                    //if using the registry give a choice to the user, infinite loop, 
                {
                    Console.WriteLine("\n1. Lägga till anställda");
                    Console.WriteLine("2. Skriva ut alla anställda");
                    Console.WriteLine("3. Exit");
                    Console.Write("Välja funktion: ");                          //prompt to the user to choose option

                    var choice = Console.ReadLine();                            //defining variable to read off the user input

                    switch (choice)                                             //using method and class based on the user input
                    {
                        case "1":
                            Console.WriteLine("Skriva anställda namn: ");
                            var name = Console.ReadLine();                      //read user input for variable

                            Console.WriteLine("Skriva anställda lön: ");
                            var salary = decimal.Parse(Console.ReadLine());     //read user input for variable 
                                                                                // TODO: Figure out how to handle the dot and comma exceptions in monetary systems... = convert everything to strings?

                            employeeRegister.AddEmployee(name, salary);         //adding Employee to the list and memory, figure out the log file
                            // TODO: figure out fixing the null value later
                            //if salary == null Console.WriteLine("Ange korrekt lön"); try using " ? " operator to include null option
                            break;

                            case "2":
                            employeeRegister.RegistryDisplay();                 //using the method to print the whole data set                       
                            break;                                              // TODO: figure out if should close the program and how to implement the log file in it

                            case "3":       // TODO: check why can't use Environment.Exit(0);
                            return;

                        default:                                                //in case user puts anything different like enter or 7, a failsafe
                            Console.WriteLine("Ange rätt siffran, testa igen. ");
                            break;
                            
                            /* try to fix null option
                            if (choice == null) Console.WriteLine("Critical error, closing program");
                            Environment.Exit(1);
                            */
                    }
                }
            }

        }

    }
}