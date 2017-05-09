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
    public class Snacks : Producto
    {

        #region Constructores

        public Snacks(EMarca marca, string codigodebarras, ConsoleColor color)
            : base(marca, codigodebarras, color)
        {
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region Métodos
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
