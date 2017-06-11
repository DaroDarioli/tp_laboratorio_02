using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;

        private Universidad.EClases _clase;

        private Profesor _intructor;

        #endregion

        #region Propiedades
        public Profesor Instructor
        {
            get { return _intructor; }
            set { _intructor = value; }
        }
            
        public Universidad.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }
                
        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        #endregion

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this ()
        {
            this._clase = clase;
            this._intructor = ValidaProfesor(instructor);
            // this._intructor = new Profesor(1, instructor.Nombre, instructor.Apellido, instructor.DNI.ToString(), instructor.Nacionalidad);

        }

        #endregion

        #region Métodos
        /// <summary>
        /// Valida que las clases del profesor recibido se correspondan con las clases de la jornada
        /// </summary>
        /// <param name="p"></param>
        private Profesor ValidaProfesor(Profesor p)
        {
            if (p == this._clase)
            {
                return p;
            }
            else
            {
                throw new SinProfesorException();
            }
        }

        /// <summary>
        /// Recibe un objeto del tipo Jornada y lo guarda en un archivo tipo .txt
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>

        public static bool Guardar(Jornada j)
        {
            Texto t1 = new Texto();
            try
            {
                ((IArchivo<string>)t1).Guardar("ArchivoJornada1.txt",j.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
               
            }          
        }

        /// <summary>
        /// Lee un archivo de tipo .txt y retorna el contenido en formato string 
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto t1 = new Texto();
            string auxRetorno;

            try
            {
                ((IArchivo<string>)t1).Leer("ArchivoJornada1.txt", out auxRetorno);
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return auxRetorno;
        }

        /// <summary>
        /// Evalua si la jornada pasada como objeto contiene al alumno pasado como parámetro en su lista 
        /// de alumnos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno b in j._alumnos)
            {
                if (b == a)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Evalua si la jornada pasada como objeto no contiene al alumno pasado como parámetro en su lista 
        /// de alumnos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {                      
            if (j == a)
                    return false;
            else
                return true;
        }

        /// <summary>
        /// Agrega un alumno pasado como parámetro a la jornada pasada como parámetro
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            
            return j;
        }


        /// <summary>
        /// Retorna los elementos del objeto en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.AppendLine("CLASE DE: " + this._clase);
            sb.Append(this._intructor.ToString());           
            sb.AppendLine("Alumnos: \n\n");

            foreach(Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Evalua si el objeto pasado como parámetro es igual al objeto jornada
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Jornada)
            {
                return (this == (Jornada)obj);
            }

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
        #endregion
    }
}

