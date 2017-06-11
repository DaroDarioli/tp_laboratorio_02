using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        #region Atributos

        private int _legajo;

        #endregion

        #region Constructores
        public Universitario(){}

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region Métodos
        
        /// <summary>
        /// Devuelve las clases en las que participa el universitario
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Devuelve los datos del objeto universitario en formato string
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            sb.AppendLine("LEGAJO NÚMERO: " + this._legajo.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Evalua si un unversitario es igual a otro de acuerdo a sus lejagos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
           return (pg1._legajo == pg2._legajo) ? true : false;
        }

        /// <summary>
        /// Evalua si un unversitario es desigual a otro de acuerdo a sus lejagos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (pg1 == pg2) ? false : true;
        }

        /// <summary>
        /// Evelua si un objeto pasado como parámetro es igual al objeto Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {

            if (obj is Universitario)
            {
                return ((Universitario)this == (Universitario)obj);
            }
            else
                return false;
        }

        /// <summary>
        /// Devuelve el legajo
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this._legajo;
        }

        #endregion
    }
}
