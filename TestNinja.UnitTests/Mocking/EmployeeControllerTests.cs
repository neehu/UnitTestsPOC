using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{

    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeRepository> _emp { get; set; }
        private EmployeeController _controller { get; set; }

        [SetUp]
        public void Setup()
        {
            _emp = new Mock<IEmployeeRepository>();
            _controller = new EmployeeController(_emp.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_RedirectsToActionEmployees()
        {
            _emp.Setup(setup => setup.DeleteEmployee(It.IsAny<int>()));

            var result = _controller.DeleteEmployee(It.IsAny<int>());

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

        [Test]
        public void DeleteEmployee_WhenCalled_EmployeeContextObjectIsCalled()
        {
            var id = It.IsAny<int>();
            var result = _controller.DeleteEmployee(id);

            _emp.Verify(em => em.DeleteEmployee(id));
        }
    }
}
