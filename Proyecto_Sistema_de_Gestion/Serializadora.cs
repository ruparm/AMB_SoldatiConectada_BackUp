using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Proyecto_Sistema_de_Gestion
{
    public static class Serializadora 
    {
     
            public static List<Socies> Leer(string path)
            {
                List<Socies> list;

                using (StreamReader sr = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Socies>));

                    list = serializer.Deserialize(sr) as List<Socies>;

                }

                return list;

            }


            public static void Escribir(List<Socies> lista, string nombre)
            {
                string path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{nombre}";

                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Socies>));
                    serializer.Serialize(sw, lista);

                }

            }
        }
}
