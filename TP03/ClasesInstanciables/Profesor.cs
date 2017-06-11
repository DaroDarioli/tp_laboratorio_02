using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {

        #region Atributos

        private Queue<Universidad.EClases> _clasesDelDia;

        private static Random _random;

        #endregion

        #region Constructores

        static Profesor()
        {
            Profesor._random = new Random();
        }

        private Profesor() : base() 
        {
            _clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad) 
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Otorga dos clases al profesor
        /// </summary>
        private void _randomClases()
        {
            AgregarUnaClase(DevolverRandom());
            AgregarUnaClase(DevolverRandom());

        }

        /// <summary>
        /// Devuelve los datos del profesor en formato string
        /// </summary>
        /// <returns></returns>

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());


            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con las clases de las que participa el profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach(Universidad.EClases e in this._clasesDelDia)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Valida que un profesor possea en su lista la clase pasada como parámetro
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>      
              
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases e in i._clasesDelDia)
            {
                if (e == clase)
                    return true;
            }

            return false;

        }

        /// <summary>
        /// Valida que un profesor no possea en su lista la clase pasada como parámetro
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases e in i._clasesDelDia)
            {
                if (e == clase)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Devuelve los datos del profesor en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Devuelve el código hash
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Iguala el método recibido con el profesor
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Profesor)
            {
                return (this == (Profesor)obj);

            }
            else
                return false;
        }

        #endregion
                
        #region Métodos Propios
        
        /// <summary>
        /// Devuelve un valor rándom teniendo en cuenta la cantidad de items en el enumerado EClases
        /// </summary>
        /// <returns></returns>
        private int DevolverRandom()
        {
            int contador = -1;
            foreach (int i in Enum.GetValues(typeof(Universidad.EClases)))
            {
                contador++;
            }

            return _random.Next(contador);

        }

        /// <summary>
        /// Agrega una clases al listado de clases del profesor dependiendo del índice que recibe como parámetro
        /// </summary>
        /// <param name="agregar"></param>
        private void AgregarUnaClase(int agregar)
        {
            switch (agregar)
            {
                case 0:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 3:
                    this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }
        #endregion
    }
}
