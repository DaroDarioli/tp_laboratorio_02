using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    
    public abstract class Persona
    {
        #region Atributos

        private string _apellido;

        private int _dni;

        private ENacionalidad _nacionalidad;

        private string _nombre;

        #endregion

        #region Propiedades

        /// <summary>
        /// Valida que el apellido tenga sólo caractéres válidos y lo setea
        /// </summary>
        public string Apellido
        {
            set {
                    try
                    {
                        if (this.ValidarNombreApellido(value) != null)
                            this._apellido = value;                    

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
               }

            get { return _apellido; }
            
        }

        /// <summary>
        /// Valida que la numeración del DNI corresponda con la nacionalidad de la persona
        /// </summary>
        public int DNI
        {
            set {

                    if (this.ValidarDni(this._nacionalidad, value) != -1)
                        this._dni = value;

                    else
                        throw new NacionalidadInvalidaException();
                }

            get { return _dni; }
        }

        /// <summary>
        /// Setea y retorna la nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        /// <summary>
        /// Valida que el nombre contenga sólo caractéres válidos y lo setea
        /// </summary>
        public string Nombre
        {
            set
            {
                try
                {
                    if (this.ValidarNombreApellido(value) != null)
                        this._nombre = value;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            get { return _nombre; }
        }

        /// <summary>
        /// Recibe un string lo valida y lo setea al atributo _dni
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int aux = ValidarDni(this._nacionalidad, value);

                if (aux != -1)
                    this._dni = aux;

                else
                    throw new NacionalidadInvalidaException();
            }
        }
        #endregion

        #region Constructores
        public Persona() { }
        
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Valida que la numeración del DNI sea congruente con la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int limite = 89999999;
            int auxRet = -1;
                   
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if(dato  < 1 || dato > limite)
                    {
                        return auxRet;
                    }
                    else
                    {
                        return dato;
                    }                                 
                case ENacionalidad.Extranjero:
                    if(dato < limite)
                    {
                        return auxRet;
                    }
                    else
                    {
                        return dato;
                    }
                   
            }
            return dato;                    
        }

        /// <summary>
        /// Valida que la numeración del DNI sea congruente con la nacionalidad de la persona 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno;
            try
            {
                retorno = int.Parse(dato);
                return  this.ValidarDni(nacionalidad, retorno);
            }
            catch(Exception e)
            {
                throw new DniInvalidoExcepcion("El DNI posee caracteres inválidaos", e);                              
            }
        }

        /// <summary>
        /// Valida que un string posea sólo letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {

            if(!(Regex.IsMatch(dato, @"^[a-zA-Z]+$")))   
                    return null;                             

            return dato;
        }

        /// <summary>
        /// Enumera las opciones entre argentino y extranjero
        /// </summary>
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion
    }  
}
