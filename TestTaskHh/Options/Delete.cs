using CommandLine;

namespace TestTaskHh.Options
{
    [Verb("delete", HelpText = "Delete employee by id")]
    public class Delete
    {
        [Option('i', "Id", Required = true, HelpText = "Id of the employee")]
        public int Id { get; set; }
    }
}
