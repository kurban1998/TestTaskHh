using CommandLine;
using TestTaskHh.Options;

namespace TestTaskHh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Add, Update, Get, GetAll, Delete>(args)
               .WithParsed<Add>(Commands.AddEmployee)
               .WithParsed<Update>(Commands.UpdateEmployee)
               .WithParsed<Get>(Commands.PrintById)
               .WithParsed<GetAll>(Commands.PrintAll)
               .WithParsed<Delete>(Commands.DeleteById);
        }
    }
}
