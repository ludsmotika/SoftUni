using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            Console.WriteLine(RemoveTown(softUniContext));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            Employee[] employees = context.Employees.OrderBy(e => e.EmployeeId).ToArray();

            StringBuilder output = new StringBuilder();
            foreach (Employee item in employees)
            {
                output.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:f2}");
            }

            return output.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            Employee[] employees = context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName).ToArray();

            StringBuilder output = new StringBuilder();
            foreach (Employee item in employees)
            {
                output.AppendLine($"{item.FirstName} - {item.Salary:f2}");
            }

            return output.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                                   .Where(e => e.Department.Name == "Research and Development")
                                   .Select(e => new { e.FirstName, e.LastName, e.Salary })
                                   .OrderBy(e => e.Salary)
                                   .ThenByDescending(e => e.FirstName)
                                   .ToArray();

            StringBuilder output = new StringBuilder();
            foreach (var item in employees)
            {
                output.AppendLine($"{item.FirstName} {item.LastName} from Research and Development - ${item.Salary:f2}");
            }

            return output.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            context.Addresses.Add(address);
            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            Employee[] employees = context.Employees.OrderByDescending(e => e.AddressId).Take(10).ToArray();
            StringBuilder output = new StringBuilder();
            foreach (Employee item in employees)
            {
                output.AppendLine($"{item.Address.AddressText}");
            }

            return output.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            Employee[] employees = context
                .Employees
                .Take(10)
                .Where
                (
                   x => x.EmployeesProjects.Any(y => (y.Project.StartDate.Year >= 2001) && (y.Project.StartDate.Year <= 2003))
                )
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (Employee item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - Manager: {item.Manager.FirstName} {item.Manager.LastName}");
                foreach (var project in item.EmployeesProjects)
                {
                    Project proj = project.Project;
                    sb.Append($"--{proj.Name} - {proj.StartDate:M/d/yyyy h:mm:ss tt} - ");
                    if (proj.EndDate == null)
                    {
                        sb.AppendLine("not finished");
                    }
                    else
                    {
                        sb.AppendLine($"{proj.EndDate:M/d/yyyy h:mm:ss tt}");
                    }
                }
            }
            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            Address[] addresses = context.Addresses.Take(10).OrderByDescending(x => x.Employees.Count).ThenBy(x => x.Town.Name).ThenBy(x => x.AddressText).ToArray();
            StringBuilder sb = new StringBuilder();

            foreach (Address item in addresses)
            {
                sb.AppendLine($"{item.AddressText}, {item.Town.Name} - {item.Employees.Count} employees");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            Employee employee = context.Employees.Find(147);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            Project[] project = employee.EmployeesProjects.Select(x => x.Project).OrderBy(x => x.Name).ToArray();
            foreach (Project item in project)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            Department[] deps = context.Departments.Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (Department item in deps)
            {
                sb.AppendLine($"{item.Name} – {item.Manager.FirstName} {item.Manager.LastName}");

                foreach (Employee employee in item.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            Project[] projects = context.Projects.OrderByDescending(x => x.StartDate).Take(10).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var item in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine(item.Name);
                sb.AppendLine(item.Description);
                sb.AppendLine($"{item.StartDate:M/d/yyyy h:mm:ss tt}");
            }
            return sb.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] valid = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            Employee[] employeeToIncrease = context.Employees.Where(x => valid.Contains(x.Department.Name)).ToArray();
            foreach (var employee in employeeToIncrease)
            {
                employee.Salary = employee.Salary * 1.12m;
            }
            context.SaveChanges();

            StringBuilder sb = new StringBuilder();
            foreach (var item in employeeToIncrease.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} (${item.Salary:f2})");
            }
            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            Employee[] employees = context.Employees.Where(x => x.FirstName.Substring(0, 2).ToLower() == "sa").ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var item in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            }
            return sb.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context) 
        {
            EmployeeProject[] employeeProjects = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToArray();
            foreach (var item in employeeProjects)
            {
                context.EmployeesProjects.Remove(item);
            }

            Project project = context.Projects.Find(2);

            context.Projects.Remove(project);

            context.SaveChanges();
            StringBuilder sb = new StringBuilder();
            foreach (var item in context.Projects.Take(10))
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context) 
        {
            Town town = context.Towns.First(x => x.Name == "Seattle");

            Address[] adresses = context.Addresses.Where(x => x.Town == town).ToArray();

            Employee[] employees = context.Employees.Where(x => adresses.Contains(x.Address)).ToArray();

            foreach (Employee item in employees)
            {
                item.AddressId = null;
            }

            int counter = 0;

            foreach (Address item in adresses)
            {
                context.Addresses.Remove(item);
                counter++;
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{counter} addresses in Seattle were deleted";
        }
    }
}
