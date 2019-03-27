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

            if(Query.IsBindingQuery(newNode.InnerText))
            {
                Query.Parse(newNode.InnerText);

                // Children Binding - not deep
                if(Query.Children)
                {
                    foreach (XmlNode node in oldNode.ChildNodes)
                    {
                        var tmpN = newNode.OwnerDocument.ImportNode(node, true);

                        newNode.RemoveAll();

                        newNode.AppendChild(tmpN);
                    }
                }
                else
                {
                    

                    
                }
            }

            foreach (XmlAttribute att in newNode.Attributes)
            {
                if (Query.IsBindingQuery(att.Value))
                {
                    Query.Parse(att.Value);

                    newNode.Attributes[Query.Property].Value = oldNode.Attributes[Query.Property]?.Value;
                }
            }
        }
    }
}