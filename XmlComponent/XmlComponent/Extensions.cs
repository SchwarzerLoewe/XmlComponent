using System.Diagnostics.Contracts;
using System.Xml;

namespace XmlComponent
{
    public static class Extensions
    {
        public static Component CreateComponent(this XmlDocument dom)
        {
            var c = new Component();

            ComponentStorage.Instance.Add(c);

            return c;
        }
        public static Component CreateComponent(this XmlDocument dom, string name, string src)
        {            
            if (src == null)
                throw new System.ArgumentNullException(nameof(src));
            if (name == null)
                throw new System.ArgumentNullException(nameof(name));

            Contract.Requires(name != null);
            Contract.Requires(src != null);

            var c = new Component();

            ComponentStorage.Instance.Add(c);

            c.Name = name;
            c.Load(src);

            return c;
        }
        public static Component CreateComponent(this XmlDocument dom, string src)
        {
            if (src == null)
                throw new System.ArgumentNullException(nameof(src));

            Contract.Requires(src != null);

            var c = new Component();
            var d = new XmlDocument();
            d.LoadXml(src);

            var node = d.DocumentElement.FirstChild;

            c.Name = d.DocumentElement.Name;
            c.Node = node;

            ComponentStorage.Instance.Add(c);

            return c;
        }

        public static XmlDocument TransformComponents(this XmlDocument dom)
        {
            foreach (XmlNode c in dom.DocumentElement.ChildNodes)
            {
                foreach (var component in ComponentStorage.Instance)
                {
                    if(c.Name == component.Name)
                    {
                        var n = dom.ImportNode(component.Node, true);

                        var binding = new Binding();

                        binding.Apply(c, n);

                        dom.DocumentElement.ReplaceChild(n, c);
                    }
                }
            }


            return dom;
        }

        public static XmlDocument TransformIncludes(this XmlDocument dom)
        {
            foreach (var item in dom.DocumentElement.SelectNodes("/include/"))
            {

            }

            return dom;
        }
    }
}