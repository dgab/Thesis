using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace NeuralNet.Serialization
{
    public class Serializer
    {
        public static string Serialize<T>(T value)
        {
            string result = string.Empty;

            if (value != null)
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));

                using (StringWriter stringWriter = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
                    //ns.Add("", "");
                    xmlserializer.Serialize(writer, value, ns);
                    result = stringWriter.ToString();
                }
            }

            return result;
        }
    }
}
