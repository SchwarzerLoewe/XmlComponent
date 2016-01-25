using System;
using System.Xml;

namespace XmlComponent
{
    public class Binding : IDisposable
    {
        public XmlAttributeCollection Attributes { get; set; }
        public XmlNodeList Children { get; set; }

        public BindingQuery Query { get; set; } = new BindingQuery();

        public void Dispose()
        {
            Attributes = null;
        }
    }
}