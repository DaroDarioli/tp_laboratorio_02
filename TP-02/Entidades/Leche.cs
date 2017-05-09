using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


/*Olinuck Dario Esteban
TP02 Programación II
UTN FRA 2017*/


namespace Entidades_2017
{
    public class Leche : Producto
    {
        #region Atributos

        public enum ETipo { Entera, Descremada }
        ETipo _tipo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>       

        public short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
            _tipo = ETipo.Entera;
        }


        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
          : base(marca, patente, color)
        {
            _tipo = tipo;
        }

        #endregion

        #region Métodos

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " +  this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
