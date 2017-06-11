using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {   
        /// <summary>
        /// Guarda en un archivo de texto los datos recibidos como string
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
      
        bool IArchivo<string>.Guardar(string archivo, string  datos)
        {

            try
            {
                using (StreamWriter sw1 = new StreamWriter(archivo)) // bloque using me asegurar liberar recursos
                {
                    sw1.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Lee un arhivo de texto y devuelve los datos como string
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.Leer(string archivo, out string datos)
        {
            bool auxRet = true;

            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    string aux;
                    do
                    {
                        aux = sr.ReadLine();
                        sb.AppendLine(aux);

                    } while (aux != null);
                   datos = sb.ToString();                
                }

            }
            catch (Exception e)
            {
                auxRet =false;
                throw new ArchivosException(e);

            }
            return auxRet;

        }

    }
}
