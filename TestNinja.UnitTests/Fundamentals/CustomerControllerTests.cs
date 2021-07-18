using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    [TestFixture]
    class CustomerControllerTests
    {

        [Test]
        public void GetCustomer_WhenIDIsZero_ReturnNotFound()
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());

        }

        [Test]
        public void GetCustomer_WhenIDIsNotZero_ReturnOK() 
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
