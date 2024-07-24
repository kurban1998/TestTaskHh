using TestTaskHh.Models;
using TestTaskHh.Options;

namespace TestTaskHh
{
    public static class Commands
    {
        public static void AddEmployee(Add options)
        {
            int newId = fM.GetNewId<Helper>();

            var newEmployee = new Employee
            {
                Id = newId,
                FirstName = options.FirstName,
                LastName = options.LastName,
                SalaryPerHour = options.Salary
            };

            fM.Write(newEmployee);
            Console.WriteLine($"Employee with id = {newId} successfully added");
        }

        public static void UpdateEmployee(Update options)
        {
            var employees = fM.ReadAll<Employee>();
            var updatedEmployee = employees.FirstOrDefault(e => e.Id == options.Id);
            if(updatedEmployee != null)
            {
                if (options.FirstName != null)
                    updatedEmployee.FirstName = options.FirstName;

                if (options.LastName != null)
                    updatedEmployee.LastName = options.LastName;

                if (options.Salary != 0)
                    updatedEmployee.SalaryPerHour = options.Salary;

                fM.OverWriteAll<Employee>(employees);
                Console.WriteLine($"Employee with id = {options.Id} successfully updated");
            }
            else
            {
                Console.WriteLine($"Employee with id = {options.Id} not found");
            }
        }

        public static void PrintById(Get options)
        {
            var employees = fM.ReadAll<Employee>();
            var employee = employees.FirstOrDefault(e => e.Id == options.Id);
            if(employee != null)
            {
                Console.WriteLine($"Id = {employee.Id}, " +
                    $"FirstName = {employee.FirstName}, " +
                    $"LastName = {employee.LastName}, " +
                    $"SalaryPerHour = {employee.SalaryPerHour}");
            }
            else
            {
                Console.WriteLine($"Employee with id = {options.Id} not found");
            }
        }

        public static void PrintAll(GetAll options)
        {
            var employees = fM.ReadAll<Employee>();
            if(employees != null)
            {
                foreach(var employee in employees)
                {
                    Console.WriteLine($"Id = {employee.Id}, " +
                    $"FirstName = {employee.FirstName}, " +
                    $"LastName = {employee.LastName}, " +
                    $"SalaryPerHour = {employee.SalaryPerHour}");
                }
            }
            else
            {
                Console.WriteLine($"Employee list is empty");
            }
        }

        public static void DeleteById(Delete options)
        {
            var employees = fM.ReadAll<Employee>();
            var deletedEmployee = employees.FirstOrDefault(e => e.Id == options.Id);
            if (deletedEmployee != null)
            {
                employees.Remove(deletedEmployee);
                fM.OverWriteAll<Employee>(employees);
                Console.WriteLine($"Employee with id = {options.Id} successfully deleted");
            }
            else
            {
                Console.WriteLine($"Employee with id = {options.Id} not found");
            }
        }

        private static FileManager fM = new("employee.json");
    }
}
