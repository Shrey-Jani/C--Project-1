// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    class Program
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 1, Name = "John Doe", Address = "123 Main St", Email = "john@example.com", Phone = "123-456-7890", Role = "Manager", VacationDays = 14 },
            new Employee { ID = 2, Name = "Jane Smith", Address = "456 Oak Ave", Email = "jane@example.com", Phone = "987-654-3210", Role = "Developer", VacationDays = 14 },
            new Employee { ID = 3, Name = "Emily Johnson", Address = "789 Pine Dr", Email = "emily@example.com", Phone = "555-555-5555", Role = "Designer", VacationDays = 14 },
            new Employee { ID = 4, Name = "Michael Brown", Address = "321 Maple Rd", Email = "michael@example.com", Phone = "444-444-4444", Role = "Tester", VacationDays = 14 },
            new Employee { ID = 5, Name = "Sarah Davis", Address = "654 Cedar Ln", Email = "sarah@example.com", Phone = "333-333-3333", Role = "Support", VacationDays = 14 }
        };

        static List<Payroll> payrolls = new List<Payroll>();
        static List<Vacation> vacations = new List<Vacation>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("Press 1 to modify employees");
                Console.WriteLine("Press 2 to add payroll");
                Console.WriteLine("Press 3 to view vacation days");
                Console.WriteLine("Press 4 to exit program");

                switch (Console.ReadLine())
                {
                    case "1":
                        EmployeeMenu();
                        break;
                    case "2":
                        PayrollMenu();
                        break;
                    case "3":
                        VacationMenu();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void EmployeeMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Employee Menu:");
                Console.WriteLine("Press 1 to list all employees");
                Console.WriteLine("Press 2 to add a new employee");
                Console.WriteLine("Press 3 to update an employee");
                Console.WriteLine("Press 4 to delete an employee");
                Console.WriteLine("Press 5 to return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListEmployees();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void PayrollMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Payroll Menu:");
                Console.WriteLine("Press 1 to insert new payroll entry");
                Console.WriteLine("Press 2 view payroll history for an employee");
                Console.WriteLine("Press 3 to return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddPayrollEntry();
                        break;
                    case "2":
                        ViewPayrollHistory();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void VacationMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Vacation Menu:");
                Console.WriteLine("Press 1 to view vacation days");
                Console.WriteLine("Press 2 to return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewVacationDays();
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListEmployees()
        {
            Console.Clear();
            Console.WriteLine("Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Address: {emp.Address}, Email: {emp.Email}, Phone: {emp.Phone}, Role: {emp.Role}, Vacation Days: {emp.VacationDays}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Add New Employee");

            var employee = new Employee();
            employee.ID = GetNextEmployeeID();

            Console.Write("Enter name: ");
            employee.Name = Console.ReadLine();

            Console.Write("Enter address: ");
            employee.Address = Console.ReadLine();

            Console.Write("Enter email: ");
            employee.Email = Console.ReadLine();

            Console.Write("Enter phone: ");
            employee.Phone = Console.ReadLine();

            Console.Write("Enter role: ");
            employee.Role = Console.ReadLine();

            employee.VacationDays = 14;

            employees.Add(employee);
            Console.WriteLine("Employee added successfully. Press any key to continue.");
            Console.ReadKey();
        }

        static void UpdateEmployee()
        {
            Console.Clear();
            Console.WriteLine("Update Employee");

            Console.Write("Enter Employee ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var employee = employees.SingleOrDefault(e => e.ID == id);

                if (employee != null)
                {
                    Console.Write("Enter new name (leave empty to keep current): ");
                    var input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                        employee.Name = input;

                    Console.Write("Enter new address (leave empty to keep current): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                        employee.Address = input;

                    Console.Write("Enter new email (leave empty to keep current): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                        employee.Email = input;

                    Console.Write("Enter new phone (leave empty to keep current): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                        employee.Phone = input;

                    Console.Write("Enter new role (leave empty to keep current): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                        employee.Role = input;

                    Console.WriteLine("Employee updated successfully. Press any key to continue.");
                }
                else
                {
                    Console.WriteLine("Employee not found. Press any key to continue.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Press any key to continue.");
            }
            Console.ReadKey();
        }

        static void DeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("Delete Employee");

            Console.Write("Enter Employee ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var employee = employees.SingleOrDefault(e => e.ID == id);

                if (employee != null)
                {
                    employees.Remove(employee);
                    Console.WriteLine("Employee deleted successfully. Press any key to continue.");
                }
                else
                {
                    Console.WriteLine("Employee not found. Press any key to continue.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Press any key to continue.");
            }
            Console.ReadKey();
        }

        static void AddPayrollEntry()
        {
            Console.Clear();
            Console.WriteLine("Add Payroll Entry");

            var payroll = new Payroll();
            payroll.ID = GetNextPayrollID();

            Console.Write("Enter Employee ID: ");
            if (int.TryParse(Console.ReadLine(), out int employeeId))
            {
                var employee = employees.SingleOrDefault(e => e.ID == employeeId);

                if (employee != null)
                {
                    payroll.EmployeeID = employeeId;

                    Console.Write("Enter hours worked: ");
                    payroll.HoursWorked = int.Parse(Console.ReadLine());

                    Console.Write("Enter hourly rate: ");
                    payroll.HourlyRate = decimal.Parse(Console.ReadLine());

                    payroll.Date = DateTime.Now;
                    payrolls.Add(payroll);

                    employee.VacationDays++;

                    Console.WriteLine("Payroll entry added successfully. Press any key to continue.");
                }
                else
                {
                    Console.WriteLine("Employee not found. Press any key to continue.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID. Press any key to continue.");
            }
            Console.ReadKey();
        }

        static void ViewPayrollHistory()
        {
            Console.Clear();
            Console.WriteLine("View Payroll History");

            Console.Write("Enter Employee ID: ");
            if (int.TryParse(Console.ReadLine(), out int employeeId))
            {
                var employee = employees.SingleOrDefault(e => e.ID == employeeId);

                if (employee != null)
                {
                    var employeePayrolls = payrolls.Where(p => p.EmployeeID == employeeId).ToList();

                    if (employeePayrolls.Any())
                    {
                        foreach (var payroll in employeePayrolls)
                        {
                            Console.WriteLine($"Payroll ID: {payroll.ID}, Hours Worked: {payroll.HoursWorked}, Hourly Rate: {payroll.HourlyRate:C}, Date: {payroll.Date}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No payroll entries found for this employee.");
                    }
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void ViewVacationDays()
        {
            Console.Clear();
            Console.WriteLine("View Vacation Days");

            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee ID: {emp.ID}, Name: {emp.Name}, Vacation Days: {emp.VacationDays}");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static int GetNextEmployeeID()
        {
            return employees.Any() ? employees.Max(e => e.ID) + 1 : 1;
        }

        static int GetNextPayrollID()
        {
            return payrolls.Any() ? payrolls.Max(p => p.ID) + 1 : 1;
        }
    }

    
    
    
}
