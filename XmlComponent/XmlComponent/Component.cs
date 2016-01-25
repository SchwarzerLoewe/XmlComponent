using System;
using System.Xml;

namespace XmlComponent
{
    public class Component
    {
        public string Name { get; set; }
        public XmlNode Node { get; set; }

        public void Load(string v)
        {
            var dom = new XmlDocument();
            dom.LoadXml($"<node>{v}</node>");

            Node = dom.DocumentElement.FirstChild;
        }
    }
}