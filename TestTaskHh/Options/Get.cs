using CommandLine;

namespace TestTaskHh.Options
{
    [Verb("get", HelpText = "Get employee by id")]
    public class Get
    {
        [Option('i', "Id", Required = true, HelpText = "Id of the employee")]
        public int Id { get; set; }
    }
}
