using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace XmlElementCombinedWithXmlText
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("person")]
    public class Person
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Text { get; set; }
        
        [XmlElement("person")]
        public Collection<Person> Children { get; set; }

        public bool ShouldSerializeChildren()
        {
            return Children != null && Children.Count > 0;
        }

        public string Serialize()
        {
            var sw = new StringWriter();

            var serializer = new XmlSerializer(typeof(Person));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(sw, this, ns);

            return sw.ToString();
        }
    }
}
