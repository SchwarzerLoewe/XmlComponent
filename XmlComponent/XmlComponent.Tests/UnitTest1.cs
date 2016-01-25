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

            dom.LoadXml("<test><hello></hello></test>");
            dom.CreateComponent("hello", "<p>hello world</p>");

            dom.TransformComponents();
        }

        [TestMethod]
        public void IncludeTest()
        {
            var dom = new XmlDocument();
            dom.LoadXml("<include src='' />");

            dom.TransformIncludes();
        }
    }
}