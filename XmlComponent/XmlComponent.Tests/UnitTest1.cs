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
            var hello = dom.CreateComponent();
            hello.Name = "hello";
            hello.Load("<p>hello world</p>");

            dom.TransformComponents();
        }

        [TestMethod]
        public void IncludeTest()
        {
        }
    }
}