using System;
using System.Diagnostics.Contracts;
using System.Xml;

namespace XmlComponent
{
    public class Component
    {
        public string Name { get; set; }
        public XmlNode Node { get; set; }

        public void Load(string v)
        {
            if (v == null)
                throw new ArgumentNullException(nameof(v));

            Contract.Requires(v != null);

            var dom = new XmlDocument();
            dom.LoadXml($"<node>{v}</node>");

            Node = dom.DocumentElement.FirstChild;
        }
    }
}