﻿using System.Xml;

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

        public static XmlDocument TransformComponents(this XmlDocument dom)
        {
            foreach (XmlNode c in dom.DocumentElement.ChildNodes)
            {
                foreach (var component in ComponentStorage.Instance)
                {
                    if(c.Name == component.Name)
                    {
                        var n = dom.ImportNode(component.Node, true);

                        dom.DocumentElement.ReplaceChild(n, c);
                    }
                }
            }


            return dom;
        }
    }
}