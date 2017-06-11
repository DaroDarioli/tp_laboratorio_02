using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private Universidad.EClases _claseQueToma;

        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores
        public Alumno(): base() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQuetoma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQuetoma;           
        }

        public Alumno(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad,Universidad.EClases claseQuetoma,EEstadoCuenta estadoCuenta): this(id,nombre,apellido,dni,nacionalidad,claseQuetoma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve los datos del elemento alumno en formato string
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("TOMA CLASE DE : " + this._claseQueToma);


            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("\nESTADO DE CUENTA: Cuota al día");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("\nESTADO DE CUENTA: Alumno becado");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("\nESTADO DE CUENTA: Adeuda cuotas");
                    break;

            }            
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve la clase que toma el alumno en formato string
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        /// <summary>
        /// Devuelve un string con los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Evalua si el alumno pasado como parámetro toma la clase también pasada como parámetro
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return ((a._claseQueToma == clase) && (a._estadoCuenta != EEstadoCuenta.Deudor))? true : false;                
        }

        /// <summary>
        /// Evalua si el alumno pasado como parámetro no toma la clase también pasada como parámetro
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma == clase) ? false : true;
        }
        
        /// <summary>
        /// Evalua si el objeto pasado como parámetro es igual al objeto Alumno
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            
            if(obj is Alumno)
            {
                return (this == (Alumno)obj);
            }            
            else
                return false;
        }

        /// <summary>
        /// Código hash para el objeto actual 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public enum EEstadoCuenta { AlDia, Deudor, Becado }
        #endregion
    }   
}
