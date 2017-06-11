using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables.Tests
{
    [TestClass()]
    public class TestUnitarios  
    {
        /// <summary>
        /// Test unitario para probar la expeción NacionalidadInvalidaException
        /// </summary>
        [TestMethod()]
        public void NacionalidadInvalidaExceptionTest()
        {

            Universidad gim = new Universidad();
            
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            
           
        }
        
        /// <summary>
        /// Test unitario para para probar la excepción AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void AlumnoRepetidoExceptionTest()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            try
            {
                if (a1 == a2)
                    Console.WriteLine("Los alumnos son iguales!!");
            }
            catch
            {
                throw new AlumnoRepetidoException();
            }


        }

        /// <summary>
        /// Test unitario para probar valores numéricos
        /// </summary>
        [TestMethod()]
        public void ValorNumericoTest()
        {
            int id = 4;
            string nombre = "Juan";
            string apellido = "Gonzalez";
            string DNI = "30456123";
            Persona.ENacionalidad nacionalidad = Persona.ENacionalidad.Argentino;
                        
            Profesor p = new Profesor(id, nombre, apellido, DNI, nacionalidad);

                if(p.DNI < 89999999)
                    Console.WriteLine("Debería ser argentino");            
            
        }

        /// <summary>
        /// Test unitario para probar valores nulos
        /// </summary>

        [TestMethod()]
        public void ValorNuloTest()
        {
            int id = 4;
            string nombre = null;
            string apellido = "Gonzalez";
            string DNI = "30456123";
            Persona.ENacionalidad nacionalidad = Persona.ENacionalidad.Argentino;
            try
            {
                Profesor p = new Profesor(id, nombre, apellido, DNI, nacionalidad);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }


    }
}