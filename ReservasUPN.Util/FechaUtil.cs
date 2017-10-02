using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.Util
{
    public class FechaUtil
    {
        //public static DateTime AgregarHoraInicial(DateTime fecha, string rangohora)
        //{
        //    string strhorainicial = rangohora.Split('-')[0].Trim();
        //    string[] partesHora = strhorainicial.Split('.');
        //    int horas = int.Parse(partesHora[0]);
        //    int minutos = int.Parse(partesHora[1]);
        //    TimeSpan horainicial = new TimeSpan(horas, minutos, 0);
        //    return fecha.Add(horainicial);
        //}

        public static DateTime AgregarHora(DateTime fecha, TimeSpan hora)
        {
            return fecha.Add(hora);
        }

        public static string DiaSemana(int i)
        {
            switch (i)
            {
                case 1:
                    return "Lunes";
                case 2:
                    return "Martes";
                case 3:
                    return "Miercoles";
                case 4:
                    return "Jueves";
                case 5:
                    return "Viernes";
                case 6:
                    return "Sabado";
                case 7:
                    return "Domingo";
            }
            return "";
        }

    }
}
