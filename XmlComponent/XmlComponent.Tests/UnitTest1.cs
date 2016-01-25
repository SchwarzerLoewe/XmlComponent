﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace XmlComponent.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComponentTest()
        {
            var dom = new XmlDocument();

            dom.LoadXml("<test><hello>world</hello></test>");
            dom.CreateComponent("<hello><p>{[children]}</p></hello>");
            dom.CreateComponent("<p><div>{[children]}</div></p>");

            dom.TransformComponents();
        }

        [TestMethod]
        public void IncludeTest()
        {
            var dom = new XmlDocument();
            dom.LoadXml("<include src='' />");

            dom.TransformIncludes();
        }

        [TestMethod]
        public void TestBindingQuery()
        {
            var q = new Binding();
            q.Query.Parse("{[chILdReN]}");

            Assert.IsTrue(q.Query.Children);
        }
    }
}