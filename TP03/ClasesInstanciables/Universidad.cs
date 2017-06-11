using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos 

        private List<Alumno> alumnos;

        private List<Jornada> jornada;

        private List<Profesor> profesores;

        #endregion

        #region Propiedades

        public List<Profesor> Profesores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        /// <summary>
        /// Indexa la lista Jornada
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>

        public Jornada this[int indice]
        {
            get
            {
                if (indice >= this.jornada.Count() || indice < 0)
                    return null; 
                               
                else              
                    return this.Jornada[indice];
                
            }             
            set
            {
                if (indice >= 0 && indice < this.jornada.Count)
                    this.jornada[indice] = value;

                else if (indice == this.jornada.Count)
                    this.jornada.Add(value);
            }
        }

        #endregion

        #region Constructores
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Verifica que el alumno esté cargado a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            foreach(Alumno b in g.Alumnos)
            {
                if (b == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que el alumno no esté cargado a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return (g == a) ? false : true;
        }

        /// <summary>
        /// Verifica que el profesor esté cargado a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor a)
        {
            foreach(Profesor b in g.Profesores)
            {
                if (b == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que el profesor no esté cargado a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor a)
        {
            return (g == a) ? false : true;
        }

        /// <summary>
        /// Agrega un alumno a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad g, Alumno a)
        {
            if (g != a)
                g.alumnos.Add(a);

            else
                throw new AlumnoRepetidoException("Alumno repetido");

            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor a)
        {
            if (g != a)
                g.profesores.Add(a);

            else
                Console.WriteLine("Profesor repetido");

            return g;

        }

        /// <summary>
        /// Verifica que la clase pertenezca a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor pAux = null;

            foreach(Profesor p in g.Profesores)
            {
                if (p == clase)
                {
                   return p;
                }
                    
            }
            return pAux;
        }

        /// <summary>
        /// Verifica que la clase no pertenezca a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            
            foreach (Profesor p in g.Profesores)
            {
                if (p == clase)
                {
                    return p;
                }

            }
            return null;
        }

        /// <summary>
        /// Devuelve los datos de la unvirsidad en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Jornada a in this.Jornada)
            {
                sb.AppendLine(a.ToString());
                sb.AppendLine("<--------------------------------------------------->");
            }
           
            return sb.ToString();
        }


       /// <summary>
       /// Agrega una clase y una jornada a la universidad
       /// </summary>
       /// <param name="g"></param>
       /// <param name="clase"></param>
       /// <returns></returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            Profesor p2 = g == clase;
            
            try
            {
             
                Jornada j1 = new Jornada(clase, p2);
                g.Jornada.Add(j1);

                foreach (Alumno a in g.Alumnos)
                {
                    if (a == clase)
                        j1 += a;
                }
            }
            catch(NullReferenceException)
            { 
                throw new SinProfesorException();           
        
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }      
            return g;       
       
        }

        /// <summary>
        /// Almacena una universidad en un archivo tipo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool auxRet = false;

            Xml<Universidad> xmlUni = new Xml<Universidad>();
            auxRet = ((IArchivo<Universidad>)xmlUni).Guardar("Registro.xml", uni);

            return auxRet;
        }

        /// <summary>
        /// Lee un archivo del tipo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Leer(Universidad uni)
        {
            bool auxRet = false;

            Xml<Universidad> xmlUni = new Xml<Universidad>();
            auxRet = ((IArchivo<Universidad>)xmlUni).Leer("Registro.xml",out uni);

            return auxRet;
        }


        /// <summary>
        /// Evalua si el objeto pasado como parámetro es igual a la unversidad
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Universidad)
            {
                return ((Universidad)this == (Universidad)obj);
            }
            return false;
        }

        /// <summary>
        /// Devuelve el código hash
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Enumerados
        /// <summary>
        /// Objeto del tipo enumerado con las materias de la universidad
        /// </summary>
        public enum EClases { Legislacion = 0, Laboratorio = 1, Programacion = 3, SPD = 3 }

        #endregion

    }

}
