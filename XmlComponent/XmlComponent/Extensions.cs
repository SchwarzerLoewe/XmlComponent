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
        public static Component CreateComponent(this XmlDocument dom, LinqComponent component)
        {
            var c = new Component();

            var name = "";

            var comp = component.CreateComponent(ref name);

            var doc = new XmlDocument();

            doc.Load(comp.CreateReader());

            c.Node = doc.DocumentElement;

            c.Name = name;

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

            if (ComponentStorage.Instance[name] == null)
            {
                ComponentStorage.Instance.Add(c);
            }

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

            if (ComponentStorage.Instance[c.Name] == null)
            {
                ComponentStorage.Instance.Add(c);
            }

            return c;
        }

        public static XmlDocument TransformComponents(this XmlDocument dom)
        {
            foreach (var component in ComponentStorage.Instance)
            {
                foreach (XmlNode c in dom.DocumentElement.ChildNodes)
                {
                    if (c.Name == component.Name)
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
            foreach (XmlNode item in dom.DocumentElement.SelectNodes("include"))
            {
                var d = new XmlDocument();
                d.Load(item.Attributes?["src"]?.Value);

                switch (item.Attributes?["type"]?.Value)
                {
                    case "text/xml":
                        var n = dom.ImportNode(d.DocumentElement, true);

                        dom.DocumentElement.ReplaceChild(n, item);

                        break;
                    case "text/component+xml":
                        dom.CreateComponent(d.ToString());

                        dom.DocumentElement.RemoveChild(item);

                        break;
                    default:
                        dom.CreateComponent(d.ToString());

                        dom.DocumentElement.RemoveChild(item);

                        break;
                }
            }

            return dom;
        }

        public static XmlDocument ApplyComponents(this XmlDocument dom)
        {
            dom.TransformIncludes();
            dom.TransformComponents();

            return dom;
        }
    }
}