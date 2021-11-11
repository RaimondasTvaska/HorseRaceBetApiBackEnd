using FluentAssertions;
using NUnit.Framework;

namespace UniteTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {

            3.Should().Be(3);
        }


    }
}