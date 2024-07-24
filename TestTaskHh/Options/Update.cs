using CommandLine;

namespace TestTaskHh.Options
{
    [Verb("update", HelpText = "Employee update")]
    public class Update
    {
        [Option('i', "Id", Required = true, HelpText = "Id of the employee")]
        public int Id { get; set; }

        [Option('f', "FirstName", Required = false, HelpText = "First name of the employee")]
        public string FirstName { get; set; }

        [Option('l', "LastName", Required = false, HelpText = "Last name of the employee")]
        public string LastName { get; set; }

        [Option('s', "Salary", Required = false, HelpText = "Salary per hour of the employee")]
        public decimal Salary { get; set; }
    }
}
