using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SeleniumNUnitExample
{
    public class TestData
    {
        public string termSearch { get; set; }

    }

    public class XmlDataReader
    {
        public static IEnumerable<TestData> ReadData(string path)
        {
            var serializer = new XmlSerializer(typeof(TestData), new XmlRootAttribute());
            using (var reader = new StreamReader(path))
            {
                return (List<TestData>)serializer.Deserialize(reader);
            }
        }
    }
}
