using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Sistema_de_Gestion
{
    public class Texto
    {
        public static void EscribirTexto(string directorio, string nombreArchivo, List<Socies> nomina)
        {
            string path = directorio + nombreArchivo;

            if (Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            StreamWriter sw = new StreamWriter(path, false);

            foreach (Socies s in nomina)
            {
                sw.WriteLine(s.ToString());
                Console.WriteLine(nomina);
            }
            sw.Close();

        }


        public static void LeerTexto(string directorio, string nombreArchivo)
        {
            string path = directorio + nombreArchivo;
            string linea;
            List<string> lista = new List<string>();

            StreamReader sr = new StreamReader(path);

            while ((linea = sr.ReadLine()) != null)
            {
                lista.Add(linea);
            }
            sr.Close();

            foreach (string nombre in lista)
            {
                Console.WriteLine(nombre);
            }
        }

    }
}
