using AutoFixture;
using FluentAssertions;
using TestTaskHh.Models;

namespace TestTaskHh.UnitTests
{
    [TestClass]
    public class CommandsTests
    {
        [TestInitialize]
        public void Initialize()
        {
            _fM = new FileManager("employee_tests.json");
        }

        [TestMethod]
        public void AddEmployee()
        {
            // arrange
            var expected = _fixture.Create<Employee>();
            _fM.OverWriteAll(new List<Employee> { expected });

            // act
            var actual = _fM.ReadAll<Employee>().First();

            // assert
            actual.Should().BeEquivalentTo(expected);
        }

        private FileManager _fM;
        private readonly Fixture _fixture = new Fixture();
    }
}