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
            dom.CreateComponent("<p><li>{title}</li></p>");

            dom.TransformComponents();
        }

        [TestMethod]
        public void CustomComponentTest()
        {
            var dom = new XmlDocument();

            dom.LoadXml("<test><people></people></test>");
            dom.CreateComponent(new TestComponent());

            dom.TransformComponents();
        }

        [TestMethod]
        public void IncludeTest()
        {
            var dom = new XmlDocument();
            dom.LoadXml("<test><include src='include.xml' type='text/xml' /></test>");

            dom.TransformIncludes();
        }

        [TestMethod]
        public void TestBindingQuery()
        {
            var q = new Binding();
            q.Query.Parse("{[chILdReN]}");

            Assert.IsTrue(q.Query.Children);
        }

        [TestMethod]
        public void TestBindings()
        {
            var dom = new XmlDocument();
            dom.CreateComponent("hello", "<p w='{world}'>{world}</p>");

            dom.LoadXml("<test><hello world='true'/>false</test>");
            dom.ApplyComponents();
            
        }
    }
}