using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01
{
    class Calculadora
    {
         /// <summary>
         /// Realiza el cálculo aritmetico elegido entre dos valores
         /// </summary>
         /// <param name="numero1">Primer valor del tipo Numero</param>
         /// <param name="numero2">Segundo valor del tipo Numero</param>
         /// <param name="operador">Una de las cuatro operaciones básicas pasadas como string</param>
         /// <returns></returns>      
        
        
        public double operar(Numero numero1,Numero numero2, string operador)
        {

            double aux1 = numero1.getNumero();
            double aux2 = numero2.getNumero();
            
            char auxOperador1 = Convert.ToChar(validarOperador(operador));
            double auxRet = 0;

            switch (auxOperador1)
            {
                case '+':
                    auxRet= aux1 + aux2;
                    break;
                case '-':
                    auxRet = aux1 - aux2;
                    break;
                case '*':
                    auxRet = aux1 * aux2;
                    break;
                case '/':
                    if (aux2 == 0)
                        auxRet = 0;
                    else
                        auxRet = aux1 / aux2;
                    break;

            }
            
            return auxRet;
        }

        public string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                operador = "+";

            return operador;
        }

    }
}
