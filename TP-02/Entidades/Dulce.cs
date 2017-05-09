using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Olinuck Dario Esteban
TP02 Programación II
UTN FRA 2017*/


namespace Entidades_2017
{
    public class Dulce : Producto
    {

        #region Constructores
        public Dulce(EMarca marca, string codigodebarras, ConsoleColor color): base(marca,codigodebarras, color)
        {
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        /// 

        #endregion

        #region Propiedades

        protected short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region Métodos

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
