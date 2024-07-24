using CommandLine;

namespace TestTaskHh.Options
{
    [Verb("add", HelpText = "Add a new employee")]
    public class Add
    {
        [Option('f', "FirstName", Required = true, HelpText = "First name of the employee")]
        public string FirstName { get; set; }

        [Option('l', "LastName", Required = true, HelpText = "Last name of the employee")]
        public string LastName { get; set; }

        [Option('s', "Salary", Required = true, HelpText = "Salary per hour of the employee")]
        public decimal Salary { get; set; }
    }
}
