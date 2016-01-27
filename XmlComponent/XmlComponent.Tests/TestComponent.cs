using System.Xml.Linq;

namespace XmlComponent.Tests
{
    public class TestComponent : LinqComponent
    {
        public override XElement CreateComponent(ref string name)
        {
            name = "people";

            return new XElement("Personen",
                       new XElement("Person",
                           new XElement("Name", "Fischer"),
                           new XElement("Vorname", "Manfred"),
                           new XElement("Alter", "45")
                       )
                   );
        }
    }
}