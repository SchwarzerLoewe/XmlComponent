using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            dom.LoadXml("<test><hello title='true'>world</hello></test>");
            dom.CreateComponent("<hello><p title='{title}'>{title}</p></hello>");

            dom.TransformComponents();
        }

        [TestMethod]
        public void IncludeTest()
        {
            var dom = new XmlDocument();
            dom.LoadXml("<include src='hello.xml' type='text/component+xml' />");

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