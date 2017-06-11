using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        /// <summary>
        /// Guarda en un archivo XML los datos pasados como parámetro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<T>.Guardar(string archivo, T datos)
        {

            try
            {
                XmlSerializer xm = new XmlSerializer(typeof(T));
                XmlTextWriter w = new XmlTextWriter(archivo, Encoding.UTF8);
                xm.Serialize(w, datos);
                w.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
           
        /// <summary>
        /// Lee un archivo del tipo XML y los carga al parametro con formato generico que se recibe
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<T>.Leer(string archivo, out T datos)
        {
            
            try
            {
                XmlSerializer xm = new XmlSerializer(typeof(T));
                XmlTextReader w = new XmlTextReader(archivo);
                datos = (T)xm.Deserialize(w);          
                w.Close();
                return true;
            }
            catch (Exception e)
            {                
                throw new ArchivosException(e);           
               
            }      
            
        }

    }
}
