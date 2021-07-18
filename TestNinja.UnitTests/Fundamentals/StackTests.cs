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
    class StackTests
    {
        public Fundamentals.Stack<string> _stack { get; set; }
        [SetUp]
        public void Setup()
        {
            _stack = new Fundamentals.Stack<string>();

        }

        [Test]
        public void Push_WhenObjectIsNull_ThrowAnException()
        {
            Assert.That(() => { _stack.Push(null); }, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_WhenObjectIsNotNull_AddItToTheStack()
        {
            _stack.Push("test");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_StackIsEmpty_CountIsZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_WhenCountIsZero_ReturnInvalidOperationException()
        {
            Assert.That(() => { _stack.Pop(); }, Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void Pop_WhenCountIsNotZero_ReturnTheTopMostElement()
        {
            _stack.Push("test2");
            _stack.Push("test1");
            _stack.Push("test");

            var result = _stack.Pop();
            Assert.That(result, Is.EqualTo("test"));

        }

        [Test]
        public void Pop_WhenCountIsNotZero_RemoveTheTopMostElement()
        {
            _stack.Push("test2");
            _stack.Push("test1");
            _stack.Push("test");

            _stack.Pop();
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenCountIsZero_ReturnInvalidOperationException()
        {

            Assert.That(() => { _stack.Peek(); },Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_WhenCountIsNOtZero_ReturnTheLastElement()
        {
            _stack.Push("test2");
            _stack.Push("test1");
            _stack.Push("test");
            var result = _stack.Peek();
            Assert.That(result, Is.EqualTo("test"));
        }

        [Test]
        public void Peek_WhenCountIsNOtZero_DoNotRemoveTheLastElement()
        {
            _stack.Push("test2");
            _stack.Push("test1");
            _stack.Push("test");
            var result = _stack.Peek();
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
