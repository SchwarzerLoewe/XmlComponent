using System;
using System.Diagnostics.Contracts;
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

        public void Apply(XmlNode oldNode, XmlNode newNode)
        {
            if (newNode == null)
                throw new ArgumentNullException(nameof(newNode));
            if (oldNode == null)
                throw new ArgumentNullException(nameof(oldNode));

            Contract.Requires(newNode != null);
            Contract.Requires(oldNode != null);

            //ToDo: Implement Binding
        }
    }
}