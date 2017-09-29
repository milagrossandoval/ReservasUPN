using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Net;

namespace ReservasUPN.Util
{
    public class Imagen
    {

        private static readonly string FOTO_DEFECTO = "../assets/images/sinfoto.jpg";
        
        public static string RutaFoto(string sede, string codigo) {
            string nombreFoto = NombreFoto(sede, codigo);
            if (ExisteImagen(nombreFoto))
            {
                return nombreFoto;
            }
            return FOTO_DEFECTO;
        }

        public static string NombreFoto(string sede, string codigo) {
            string ruta = ConfigurationManager.AppSettings["RutaFoto"];
            string unidadNegocio="U";
            if(sede.Substring(0,3)=="UPN"){
                unidadNegocio += sede.Substring(3);
            }
            else if(sede.Substring(0,2)=="WA"){
                unidadNegocio += sede.Substring(2);
            }

            codigo = codigo.PadLeft(6, '0');
            return ruta + unidadNegocio + codigo;
        }

        private static bool ExisteURI(string foto) {
            return File.Exists(foto);
        }

        private static bool ExisteURL(string url)
        {
            bool result = true;

            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Timeout = 1200; // miliseconds
            webRequest.Method = "HEAD";

            try
            {
                webRequest.GetResponse();
            }
            catch
            {
                result = false;
            }

            return result;
        }


        public static bool ExisteImagen(string foto){
            string ruta = ConfigurationManager.AppSettings["TipoRutaFoto"];
            if (ruta == "url") {
                return ExisteURL(foto);
            }
            else if (ruta == "uri") {
                return ExisteURI(foto);
            }
            return false;
        }

    }
}
