using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicio
{
    public class GeneradorClave
    {
        static string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%abcdefghijklmnopqrstuvwxyz0123456789";
        static char[] stringCaracteres = new char[16];
        static Random random = new Random();

        public class ContraseniaException : Exception
        {
            public ContraseniaException() { }
            public ContraseniaException(string mensaje) : base(mensaje) { }
            public ContraseniaException(string mensaje, Exception inner) : base(mensaje, inner) { }

        }
        public static void ValidarContrasenia(string pString)
        {
            Regex mContraseniaRegex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{11,}$");
            if (!mContraseniaRegex.IsMatch(pString))
            {
                throw new ContraseniaException("Contrasenia No Valida");
            }
        }
        public static string CrearRandomContrasenia()
        {
            try
            {
                for (int i = 0; i < stringCaracteres.Length; i++)
                {
                    stringCaracteres[i] = caracteres[random.Next(caracteres.Length)];
                }
                String finalString = new String(stringCaracteres);
                return finalString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static void EnviarNuevaContrasenia(string pPWD, string pTo)
        {
            try
            {
                string mAsunto = "TECHBOTICA - Nueva contraseña";
                string mMensaje = "La clave para que accedas al sistema es:\t" + pPWD;
                Notificacion.EnviarEmail(mMensaje, mAsunto, pTo);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
