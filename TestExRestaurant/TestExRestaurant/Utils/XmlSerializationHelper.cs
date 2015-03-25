using System.IO;
using System.Xml.Serialization;

namespace TestExRestaurant.Utils
{
    /// <summary>
    /// Standart serialization helper class
    /// </summary>
    public abstract class XmlSerializationHelper
    {
        public static T Load<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            T obj;

            using (TextReader reader = new StreamReader(fileName))
            {
                obj = (T)serializer.Deserialize(reader);
            }
            
            return obj;
        }

        public static void Save<T>(T obj, string fileName)
        {
            using (TextWriter writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
            }
        }
    }
}
