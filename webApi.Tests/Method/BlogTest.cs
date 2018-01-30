using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webCore.services;
using Moq;
using webCore;
using webCore.common;
using PetaPoco;

namespace webApi.Tests.Method
{
    [TestClass]
    public class BlogTest
    {
        [TestMethod]
        public void blog()
        {
            var blog_mock = new Mock<IBlogServices>();
            var pagi_mock = new Mock<paging>();
            blog_mock.Setup(r => r.blog<blog>(pagi_mock.Object)).Returns(new Page<blog>()).Verifiable();
            var blog = blog_mock.Object.blog<blog>(pagi_mock.Object);
            Assert.IsNotNull(blog);
        }

    }
}
