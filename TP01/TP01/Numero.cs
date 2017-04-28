using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01
{
    public class Numero
    {
        private double numero; 


        /// <summary>
        /// Crea espacio en memoria e inicializa el atributo numero de la clase Numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;    
        }
        /// <summary>
        /// Crea espacio en memoria e inicializa el atributo numero de la clase Numero con el valor que se le pasa como string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            double aux = 0;
            
            double.TryParse(strNumero, out aux); 
               
            this.numero = aux;
        }

        /// <summary>
        /// Retorna el atributo del tipo double numero de la clase Numero
        /// </summary>
        /// <returns> el atributo del tipo double</returns>

        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Recibe un dato del tipo double y lo carga en el atributo numero de la clase Numero
        /// </summary>
        /// <param name="dblNumero"></param>
        public Numero(double dblNumero)
        {
            this.numero = dblNumero;
        }


        /// <summary>
        /// Recibe una cadena de caracteres y si es doble la carga al atributo numero de la clase Numero
        /// </summary>
        /// <param name="strNumero"></param>
        private void setNumero(string strNumero)
        {
            this.numero = validarNumero(strNumero);
        }


        /// <summary>
        /// Recibe un string, lo valida y si es sólo numérico lo devuelve como double
        /// </summary>
        /// <param name="strNumero">Una cadena de carctéres</param>
        /// <returns>La cadena de caractéres convertida en double, o 0 si no pudo realizar la conversión</returns>
        private double validarNumero(string strNumero)
        {
            double aux = 0;

            double.TryParse(strNumero, out aux);

            return aux;
        }   

       
    }
}
